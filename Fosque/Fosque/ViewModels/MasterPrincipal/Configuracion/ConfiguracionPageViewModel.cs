using System;
using Fosque.ViewModels.Base;
using System.Diagnostics;
using Fosque.Services;
using Fosque.Models;
using Fosque.Helpers;
using Fosque.DbLocal;
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
        }
        #endregion

        #region Methods
        private async void OnTapToggled()
        {
            try
            {
                var db = new DbContext();
                var user = db.GetUsuario();
                //var response = await client.GetListAllWithParam<bool>(Configuration.BaseUrl, $"pnl/spapp/ws_token_push_status?client={user.Client}&player={user.p}&token=" + token");
            }
            catch(Exception ex)
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
                //DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                //var response = await client.GetListAllWithParam<ConfiguracionModel>(Configuration.BaseUrl, $"/pnl/spapp/ws_token_push_status?client=" + user.Client + "&player=" + user. + "&token=" + token);
                //DependencyService.Get<IProgressDialog>().ProgressDialogShow();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
