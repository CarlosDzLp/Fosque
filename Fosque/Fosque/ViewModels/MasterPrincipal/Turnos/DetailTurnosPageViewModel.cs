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
using System.Linq;
using Newtonsoft.Json;

namespace Fosque.ViewModels.MasterPrincipal.Turnos
{
    public class DetailTurnosPageViewModel : BindableBase
    {
        #region Properties
        private string IDDetail;
        private DetailTurnosModel detail;
        public DetailTurnosModel Detail
        {
            get { return detail; }
            set { SetProperty(ref detail, value); }
        }
        private bool isEnabled = true;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }
        #endregion

        #region Constructor
        public DetailTurnosPageViewModel(string Id)
        {
            IDDetail = Id;
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
                    if (response.Count > 0)
                    {
                        var model = response.FirstOrDefault();
                        Detail = new DetailTurnosModel();
                        Detail = model;
                    }
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
        private async void ReservaClaseCommandExecuted()
        {
            try
            {
                DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                var db = new DbContext();
                var user = db.GetUsuario();
                ServiceClient client = new ServiceClient();
                var response = await client.GetListAllWithParam<ResponseMessage>(Configuration.BaseUrl, $"pnl/spapp/wsturnero_reserva?client={user.Client}&id={IDDetail}&socio={user.IdUser}");
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();

                if (response.StatusCode == 200)
                {
                    IsEnabled = false;
                    App.MessageSuccess(response.Mensaje);
                }
                else
                {
                    App.MessageError(response.Mensaje);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }

    public class ResponseMessage
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }
    }
}
