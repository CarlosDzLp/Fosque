using System;
using Fosque.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using Fosque.Dependency;
using Fosque.Services;
using Fosque.Models;
using Fosque.DbLocal;
using Fosque.Helpers;
using System.Diagnostics;

namespace Fosque.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        #region Properties
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { SetProperty(ref usuario, value); }
        }
        private string documento;
        public string Documento
        {
            get { return documento; }
            set { SetProperty(ref documento, value); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        private bool isToggled;
        public bool IsToggled
        {
            get { return isToggled; }
            set { SetProperty(ref isToggled, value); }
        }

        private bool isUsuario;
        public bool IsUsuario
        {
            get { return isUsuario; }
            set { SetProperty(ref isUsuario, value); }
        }
        private bool isDocumento;
        public bool IsDocumento
        {
            get { return isDocumento; }
            set { SetProperty(ref isDocumento, value); }
        }
        private bool isContrasena;
        public bool IsContrasena
        {
            get { return isContrasena; }
            set { SetProperty(ref isContrasena, value); }
        }
        #endregion

        #region constructor
        public LoginPageViewModel()
        {
            IsUsuario = false;
            IsDocumento = false;
            IsContrasena = false;
            IsToggled = false;
            LoginCommand = new Command(LoginCommandExecuted);
            ForgotPasswordCommand = new Command(ForgotPasswordCommandExecuted);
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        #endregion

        #region CommandsExecuted
        private async void LoginCommandExecuted()
        {
            if(!string.IsNullOrEmpty(Usuario))
            {
                if(!string.IsNullOrEmpty(Documento))
                {
                    if(!string.IsNullOrEmpty(Password))
                    {
                        //servicio
                        ServiceClient client = new ServiceClient();
                        IsUsuario = false;
                        IsDocumento = false;
                        IsContrasena = false;
                        DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                        var query = $"pnl/spapp/validasocio?client=8eb67d8619543d947ad8ab7f9f9597ecca84fb7d&email={Usuario}&dni={Documento}&pass={Password}";
                        var response = await client.GetListAllWithParam<UsuarioModel>(Configuration.BaseUrl, query);
                        if (response != null)
                        {
                            if (response.StatusCode == "200")
                            {
                                Insert(response);
                                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                                App.Current.MainPage = new Views.Principal.MasterPage();
                            }
                            else
                            {
                                App.MessageError(response.Mensaje);
                            }
                        }
                        else
                        {
                            App.MessageError("Verifique su conexion a internet");
                        }
                        DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                    }
                    else
                    {
                        IsUsuario = false;
                        IsDocumento = false;
                        IsContrasena = true;
                    }
                }
                else
                {
                    IsUsuario = false;
                    IsDocumento = true;
                    IsContrasena = false;
                }
            }
            else
            {
                IsUsuario = true;
                IsDocumento = false;
                IsContrasena = false;
            }
        }
        private void ForgotPasswordCommandExecuted()
        {

        }

        private void Insert(UsuarioModel usuario)
        {
            DbContext db = new DbContext();
            db.DeleteUsuario();
            usuario.IsRemember = IsToggled;
            db.Insertusuario(usuario);
        }

        //ver en que parte poner este codigo
        private async void GetToken()
        {
            try
            {
                DbContext db = new DbContext();
                ServiceClient client = new ServiceClient();
                var user = db.GetUsuario();
                var deviceinfo = Plugin.DeviceInfo.CrossDeviceInfo.Current;
                var dependency = DependencyService.Get<IFilePath>().GetLenguages();
                //var response = await client.GetListAllWithParam<string>(Configuration.BaseUrl, $"pnl/spapp/ws_registro_token?client={user.Client}&socio={user.IdUser}&player={}&token={}&plataforma={deviceinfo.Platform}&version={deviceinfo.Version}&pais={dependency}&versapp={deviceinfo.AppVersion}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
