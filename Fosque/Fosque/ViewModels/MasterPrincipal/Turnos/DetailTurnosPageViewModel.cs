using System;
using Fosque.ViewModels.Base;
using System.Diagnostics;
using Xamarin.Forms;
using Fosque.Dependency;
using Fosque.DbLocal;
using Fosque.Services;
using Fosque.Helpers;
using Fosque.Models;
using System.Windows.Input;
using System.Collections.Generic;

namespace Fosque.ViewModels.MasterPrincipal.Turnos
{
    public class DetailTurnosPageViewModel : BindableBase
    {
        #region Properties
        private DetailTurnosModel detail;
        public DetailTurnosModel Detail
        {
            get { return detail; }
            set { SetProperty(ref detail, value); }
        }
        #endregion

        #region Constructor
        public DetailTurnosPageViewModel(string Id)
        {
            ReservaClaseCommand = new Command(ReservaClaseCommandExecuted);
            LoadDetailTurnos(Id);
        }
        #endregion

        #region Methods
        private async void LoadDetailTurnos(string Id)
        {
            try
            {
                DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                var db = new DbContext();
                var user = db.GetUsuario();
                ServiceClient client = new ServiceClient();
                var response = await client.GetListAllWithParam<List<DetailTurnosModel>>(Configuration.BaseUrl, $"pnl/spapp/wsturnero_detalle?client={user.Client}&id={Id}");
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                if (response != null)
                {

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Command
        public ICommand ReservaClaseCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void ReservaClaseCommandExecuted()
        {
            try
            {

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
