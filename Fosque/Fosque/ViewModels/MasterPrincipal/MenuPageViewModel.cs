using System;
using Fosque.ViewModels.Base;
using System.Collections.ObjectModel;
using Fosque.Models;
using Fosque.Views.Principal;
using Fosque.DbLocal;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
namespace Fosque.ViewModels.MasterPrincipal
{
    public class MenuPageViewModel : BindableBase
    {
        #region Properties
        private ObservableCollection<MenuLateral> listMenuLateral;
        public ObservableCollection<MenuLateral> ListMenuLateral
        {
            get { return listMenuLateral; }
            set { SetProperty(ref listMenuLateral, value); }
        }

        private MenuLateral itemSelectedMenu;
        public MenuLateral ItemSelectedMenu
        {
            get { return itemSelectedMenu; }
            set
            {
                if(itemSelectedMenu!=value)
                {
                    SetProperty(ref itemSelectedMenu, value);
                    OnSelectedMenu();
                }
            }
        }
        #endregion

        #region Constructor
        public MenuPageViewModel()
        {
            PopulatingMenu();
        }
        #endregion

        #region Methods
        private void PopulatingMenu()
        {
            ListMenuLateral = new ObservableCollection<MenuLateral>();
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Perfil",
                ImageMenu = "profile.png",
                NamePage = new PerfilPage()
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Contratos",
                ImageMenu = "membership.png",
                NamePage = new ContratosPage()
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Reserva de turnos",
                ImageMenu = "turnos.png",
                NamePage = new TurnosPage()
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Mis reservas",
                ImageMenu = "reloj.png",
                NamePage = new ReservasPage()
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Mi plan entrenamiento",
                ImageMenu = "planes.png",
                NamePage = new PlanPage()
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Configuracion",
                ImageMenu = "config.png",
                NamePage = new ConfiguracionPage()
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Cerra Sesion",
                ImageMenu = "salir.png",
                NamePage = null
            });
        }
        private void OnSelectedMenu()
        {
            if (ItemSelectedMenu != null)
            {
                if (ItemSelectedMenu.NamePage == null)
                {
                    DbContext db = new DbContext();
                    db.DeleteUsuario();
                    App.Current.MainPage = App.GetNavigationPage(new Views.Session.LoginPage());
                }
                else
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(ItemSelectedMenu.NamePage);
                }
            }
        }
        #endregion
    }
}
