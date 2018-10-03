using System;
using Fosque.ViewModels.Base;
using System.Collections.ObjectModel;
using Fosque.DbLocal;
using Fosque.Services;
using System.Collections.Generic;
using Fosque.Models;
using System.Xml.Xsl;
using Xamarin.Forms;
using System.IO;
using Fosque.Helpers;
using System.Diagnostics;
using Fosque.Views.Principal.MisPlanes;
using System.Windows.Input;
using Fosque.Dependency;

namespace Fosque.ViewModels.MasterPrincipal.Plan
{
    public class MiPlanPageViewModel : BindableBase
    {
        #region Properties
        private ObservableCollection<PlanEntrenamiento> listPlanes;
        public ObservableCollection<PlanEntrenamiento> ListPlanes
        {
            get { return listPlanes; }
            set { SetProperty(ref listPlanes, value); }
        }

        private PlanEntrenamiento selectedPlan;
        public PlanEntrenamiento SelectedPlan
        {
            get { return selectedPlan; }
            set
            {
                if (selectedPlan != value)
                {
                    SetProperty(ref selectedPlan, value);
                    OnSelectedPlan();
                }
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        #endregion

        #region Constructor
        public MiPlanPageViewModel()
        {
            GetPlanUser();
            IsBusyCommand = new Command(GetPlanUser);
        }
        #endregion

        #region Methods
        private async void GetPlanUser()
        {
            DependencyService.Get<IProgressDialog>().ProgressDialogShow();
            IsBusy = true;
            ListPlanes = new ObservableCollection<PlanEntrenamiento>();
            ListPlanes.Clear();
            ServiceClient client = new ServiceClient();
            DbContext db = new DbContext();
            var result = db.GetUsuario();
            var query = $"pnl/spapp/ws_planentrenamiento_vigente?client={result.Client}&socio={result.IdUser}";
            var response = await client.GetListAllWithParam<List<PlanEntrenamiento>>(Configuration.BaseUrl, query);
            DependencyService.Get<IProgressDialog>().ProgressDialogHide();
            if (response != null)
            {
                if (response.Count > 0)
                {
                    foreach (var items in response)
                    {
                        items.ImageBase = ImageConvert.ConvertToBase(items.Foto);
                        ListPlanes.Add(items);
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

        private void OnSelectedPlan()
        {
            try
            {
                if (SelectedPlan != null)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new DetallePlanPage(SelectedPlan));
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
        #endregion
    }
}
