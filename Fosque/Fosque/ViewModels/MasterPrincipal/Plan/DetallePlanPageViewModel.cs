using System;
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
using Fosque.Dependency;

namespace Fosque.ViewModels.MasterPrincipal.Plan
{
    public class DetallePlanPageViewModel : BindableBase
    {
        #region Properties
        private PlanEntrenamiento _plan;
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private ObservableCollection<SubPlanEntrenamiento> listSubPlan;
        public ObservableCollection<SubPlanEntrenamiento> ListSubPlan
        {
            get { return listSubPlan; }
            set { SetProperty(ref listSubPlan, value); }
        }
        #endregion

        #region Constructor
        public DetallePlanPageViewModel(PlanEntrenamiento plan)
        {
            _plan = new PlanEntrenamiento();
            _plan = plan;
            GetSubPlanUser();
            IsBusyCommand = new Command(GetSubPlanUser);
        }
        #endregion

        #region Methods

        private async void GetSubPlanUser()
        {
            IsBusy = true;
            ListSubPlan = new ObservableCollection<SubPlanEntrenamiento>();
            ListSubPlan.Clear();
            ServiceClient client = new ServiceClient();
            DbContext db = new DbContext();
            var result = db.GetUsuario();
            var query = $"pnl/spapp/ws_planentrenamiento_planes?client={result.Client}&socio={result.IdUser}& id={_plan.ID}";
            var response = await client.GetListAllWithParam<List<SubPlanEntrenamiento>>(Configuration.BaseUrl, query);
            if (response != null)
            {
                if (response.Count > 0)
                {
                    foreach (var items in response)
                    {
                        if (!string.IsNullOrEmpty(items.Imagen))
                        {
                            items.IsVisibleText = false;
                            items.IsVisibleImage = true;
                            items.ImageConvert = ImageConvert.ConvertToBase(items.Imagen);
                        }
                        else
                        {
                            items.IsVisibleText = true;
                            items.IsVisibleImage = false;
                        }
                        ListSubPlan.Add(items);
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

        private void OnTapSelectedSubPlan(SubPlanEntrenamiento SelectedSubPlan)
        {
            try
            {
                if (SelectedSubPlan != null)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new PlanRutinaEntranamientoPage(SelectedSubPlan,_plan.ID));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Command
        public ICommand IsBusyCommand { get; set; }
        public ICommand ItemClickCommand 
        {
            get
            {
                return new Command((item) =>
                {
                    var selected = item as SubPlanEntrenamiento;
                    OnTapSelectedSubPlan(selected);
                });
            }
        }
        #endregion
    }
}
