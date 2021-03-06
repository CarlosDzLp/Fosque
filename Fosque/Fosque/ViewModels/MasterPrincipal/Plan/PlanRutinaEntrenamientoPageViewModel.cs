﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fosque.DbLocal;
using Fosque.Helpers;
using Fosque.Models;
using Fosque.Services;
using Fosque.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using Fosque.Views.Principal.MisPlanes;
using Rg.Plugins.Popup.Extensions;
using System.Linq;
using System.IO;
using Fosque.Dependency;

namespace Fosque.ViewModels.MasterPrincipal.Plan
{
    public class PlanRutinaEntrenamientoPageViewModel : BindableBase
    {
        #region Properties
        private string _idPlan;
        private bool isBusy;
        private string typeSubPlan;
        public string TypeSubPlan
        {
            get { return typeSubPlan; }
            set { SetProperty(ref typeSubPlan, value); }
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        private ObservableCollection<PlanEntrenamientoEjercicios> listEjercicios;
        public ObservableCollection<PlanEntrenamientoEjercicios> ListEjercicios
        {
            get { return listEjercicios; }
            set
            {
                SetProperty(ref listEjercicios, value);
            }
        }

        private SubPlanEntrenamiento _subPlan;
        #endregion

        #region Constructor
        public PlanRutinaEntrenamientoPageViewModel(SubPlanEntrenamiento subplan, string idPlan)
        {
            _idPlan = idPlan;
            _subPlan = new SubPlanEntrenamiento();
            _subPlan = subplan;
            TypeSubPlan = _subPlan.Plan;
            GetEntrenamiento();
            IsBusyCommand = new Command(GetEntrenamiento);
        }
        #endregion

        #region Methods
        private async void GetEntrenamiento()
        {
            IsBusy = true;
            ListEjercicios = new ObservableCollection<PlanEntrenamientoEjercicios>();
            ListEjercicios.Clear();
            ServiceClient client = new ServiceClient();
            DbContext db = new DbContext();
            var result = db.GetUsuario();
            var query = $"pnl/spapp/ws_planentrenamiento_planes_ejercicios?client={result.Client}&socio={result.IdUser}&id={_idPlan}&tipo={_subPlan.Tipo}";
            var response = await client.GetListAllWithParam<List<PlanEntrenamientoEjercicios>>(Configuration.BaseUrl, query);
            if (response != null)
            {
                if (response.Count > 0)
                {
                    foreach (var item in response)
                    {
                         item.ImageConvert = ImageConvert.ConvertToBase(item.Photo);
                        ListEjercicios.Add(item);
                    }
                }
                else
                {
                    App.MessageError("No hay datos");
                }
            }
            else
            {
                App.MessageError("Intentelo mas tarde");
            }
            IsBusy = false;
        }
        private void OnSelectedEjercicios(PlanEntrenamientoEjercicios SelectedEjercicios)
        {
            try
            {
                if (SelectedEjercicios != null)
                {
                    if (string.IsNullOrEmpty(SelectedEjercicios.Photo) && string.IsNullOrEmpty(SelectedEjercicios.Photo))
                    {
                        //SelectedEjercicios.Video = "imagenotfound.png";
                        //App.MasterPageDetail.IsPresented = false;
                        //App.MasterPageDetail.Detail.Navigation.PushAsync(new ImageGifPage(SelectedEjercicios), true);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(SelectedEjercicios.Video))
                        {
                            string[] images = { ".gif" };

                            if (images.Contains(Path.GetExtension(SelectedEjercicios.Video)))
                            {
                                App.MasterPageDetail.IsPresented = false;
                                App.MasterPageDetail.Detail.Navigation.PushAsync(new ImageGifPage(SelectedEjercicios), true);
                            }
                            else
                            {
                                App.MasterPageDetail.IsPresented = false;
                                App.MasterPageDetail.Detail.Navigation.PushAsync(new PopupEjercicios(SelectedEjercicios), true);
                            }
                        }
                        else
                        {
                            var image = ImageConvert.ConvertToBase(SelectedEjercicios.Photo);
                            SelectedEjercicios.ImageConvert = image;
                            App.MasterPageDetail.IsPresented = false;
                            App.MasterPageDetail.Detail.Navigation.PushAsync(new ImageEjerciciosPage(SelectedEjercicios), true);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Commands
        public ICommand IsBusyCommand { get; set; }
        public ICommand ItemClickCommand
        {
            get
            {
                return new Command((item) =>
                {
                    var selected = item as PlanEntrenamientoEjercicios;
                    OnSelectedEjercicios(selected);
                });
            }
        }
        #endregion

    }
}
