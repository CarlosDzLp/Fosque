using System;
using Fosque.ViewModels.Base;
using System.Diagnostics;
using Fosque.Services;
using Fosque.DbLocal;
using Fosque.Models;
using Fosque.Helpers;
using Xamarin.Forms;
using Fosque.Dependency;
namespace Fosque.ViewModels.MasterPrincipal.Perfil
{
    public class PerfilViewModel : BindableBase
    {
        #region Properties
        private PerfilModel perfil;
        public PerfilModel Perfil
        {
            get { return perfil; }
            set{
                SetProperty(ref perfil, value);
            }
        }
        #endregion

        #region Contructor
        public PerfilViewModel()
        {
            LoadPerfil();
        }
        #endregion

        #region Methods
        private async void LoadPerfil()
        {
            try
            {
                DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                Perfil = new PerfilModel();
                var db = new DbContext();
                var user = db.GetUsuario();
                ServiceClient client = new ServiceClient();
                var response = await client.GetListAllWithParam<PerfilModel>(Configuration.BaseUrl, $"pnl/api/get_membresias_socioApp?client={user.Client}&socio={user.DNI}");
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                if (response != null)
                {
                    Perfil = response;
                    Perfil.PhotoConvert = ImageConvert.ConvertToBase(response.Photo);
                    Perfil.Domicilio = response.Domicilio + " " + response.Numeracion;
                    Perfil.Telefono = response.CaractTelefono + " " + response.Telefono;
                    Perfil.Celular = response.CaractCelular + " " + response.Celular;
                }
                else
                {
                    App.MessageError("Usuario no encontrado");
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
