using System;
using Fosque.ViewModels.Base;
using System.Diagnostics;
using Fosque.Services;
using Fosque.DbLocal;
using System.Collections.Generic;
using Fosque.Models;
using Fosque.Helpers;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Fosque.Dependency;
using System.Windows.Input;
using Fosque.Views.Principal.MisTurnos;
namespace Fosque.ViewModels.MasterPrincipal.Turnos
{
    public class TurnosPageViewModel : BindableBase
    {
        #region Properties
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        private ObservableCollection<ReservaTurnosModel> listReservas;
        public ObservableCollection<ReservaTurnosModel> ListReservas
        {
            get { return listReservas; }
            set { SetProperty(ref listReservas, value); }
        }
        #endregion

        #region Constructor
        public TurnosPageViewModel()
        {
            LoadTurnos();
            IsBusyCommand = new Command(LoadTurnos);
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
                    var selected = item as ReservaTurnosModel;
                    OnTapSelectedReserva(selected);
                });
            }
        }
        #endregion

        #region Methods
        private async void LoadTurnos()
        {
            try
            {
                IsBusy = true;
                ListReservas = new ObservableCollection<ReservaTurnosModel>();
                ListReservas.Clear();
                ServiceClient client = new ServiceClient();
                var db = new DbContext();
                var user = db.GetUsuario();
                var response = await client.GetListAllWithParam<List<ReservaTurnosModel>>(Configuration.BaseUrl, $"pnl/spapp/wsturnero?client={user.Client}&sede={user.Sede}");
                if (response!=null)
                {
                    if (response.Count > 0)
                    {
                        foreach (var item in response)
                        {
                            ListReservas.Add(item);
                        }
                    }
                }
                else
                {
                    App.MessageError("No se pudo cargar la vista");
                }
                IsBusy = false;
            }
            catch(Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        private void OnTapSelectedReserva(ReservaTurnosModel SelectedReserva)
        {
            try
            {
                if(SelectedReserva != null)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new DetailTurnosPage(SelectedReserva.Id));
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
