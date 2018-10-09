using System;
using Fosque.ViewModels.Base;
using System.Diagnostics;
using Fosque.Services;
using Fosque.Models;
using Fosque.Helpers;
using Fosque.DbLocal;
using Xamarin.Forms;
using Fosque.Dependency;
using ZXing;

namespace Fosque.ViewModels.MasterPrincipal.Configuracion
{
    public class ConfiguracionPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();
        #region Properties
        private bool isToggled;
        public bool IsToggled
        {
            get { return isToggled; }
            set
            {
                if (isToggled != value)
                {
                    SetProperty(ref isToggled, value);
                    OnTapToggled();
                }
            }
        }
        #endregion

        #region Constructor
        public ConfiguracionPageViewModel()
        {
            IsToggled = false;
            LoadConfiguration();
        }
        #endregion

        #region Methods
        private async void OnTapToggled()
        {
            try
            {
                var db = new DbContext();
                var user = db.GetUsuario();
                DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                //var response = await client.GetListAllWithParam<ConfiguracionModel>(Configuration.BaseUrl, $"pnl/spapp/ws_token_push_update?client={user.Client}&player={}&token={}&status={IsToggled}");
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                //if(!string.IsNullOrEmpty(response.Token))
                //{
                  //  IsToggled = Convert.ToBoolean(response.StatusCode);
                //}
                //else
                //{
                    App.MessageError("Intentelo mas tarde");
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private async void LoadConfiguration()
        {
            try
            {
                var db = new DbContext();
                var user = db.GetUsuario();
                DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                //var response = await client.GetListAllWithParam<ConfiguracionModel>(Configuration.BaseUrl, $"/pnl/spapp/ws_token_push_status?client={user.Client}&player={}&token={}");
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                //if(!string.IsNullOrEmpty(response.Token))
                //{
                   // IsToggled = Convert.ToBoolean(response.StatusCode);
                //}
                //else
                //{
                    App.MessageError("hubo un error intentelo mas tarde");
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
