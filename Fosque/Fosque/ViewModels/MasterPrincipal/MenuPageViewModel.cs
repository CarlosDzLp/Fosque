using System;
using Fosque.ViewModels.Base;
using System.Collections.ObjectModel;
using Fosque.Models;
using Fosque.DbLocal;
using Fosque.Views.Principal.MiPerfil;
using Fosque.Views.Principal.MisContratos;
using Fosque.Views.Principal.MisTurnos;
using Fosque.Views.Principal.MisReservas;
using Fosque.Views.Principal.MisPlanes;
using Fosque.Views.Principal.MiConfiguarion;

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
                id = 1
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Contratos",
                ImageMenu = "membership.png",
                id = 2
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Reservas de turnos",
                ImageMenu = "turnos.png",
                id = 3
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Mis reservas",
                ImageMenu = "reloj.png",
                id = 4
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Mi plan entrenamiento",
                ImageMenu = "planes.png",
                id = 5
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Configuracion",
                ImageMenu = "config.png",
                id = 6
            });
            ListMenuLateral.Add(new MenuLateral
            {
                TitleMenu = "Cerra Sesion",
                ImageMenu = "salir.png",
                id = 0
            });
        }
        private void OnSelectedMenu()
        {
            if (ItemSelectedMenu != null)
            {
                if (ItemSelectedMenu.id == 0)
                {
                    DbContext db = new DbContext();
                    db.DeleteUsuario();
                    App.Current.MainPage = App.GetNavigationPage(new Views.Session.LoginPage());
                }
                else if(ItemSelectedMenu.id == 1)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new MiPerfilPage());
                }
                else if (ItemSelectedMenu.id == 2)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new MisContratosPage());
                }
                else if (ItemSelectedMenu.id == 3)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new MisTurnosPage());
                }
                else if (ItemSelectedMenu.id == 4)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new MisReservasPage());
                }
                else if (ItemSelectedMenu.id == 5)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new MiPlanPage());
                }
                else if (ItemSelectedMenu.id == 6)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new MiConfiguracionPage());
                }
            }
        }
        #endregion
    }
}
