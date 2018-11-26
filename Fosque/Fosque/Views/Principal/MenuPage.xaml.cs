using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Fosque.Models;
using Fosque.Views.Principal.MiPerfil;
using Fosque.DbLocal;
using Fosque.Views.Principal.MisContratos;
using Fosque.Views.Principal.MisTurnos;
using Fosque.Views.Principal.MisReservas;
using Fosque.Views.Principal.MisPlanes;
using Fosque.Views.Principal.MiConfiguarion;
using Fosque.Helpers;

namespace Fosque.Views.Principal
{
    public partial class MenuPage : ContentPage
    {
        DbContext db = new DbContext();
        public ObservableCollection<MenuLateral> ListMenuLateral;
        public MenuPage()
        {
            InitializeComponent();
            var user = db.GetUsuario();
            ImageLogo.Source = ImageConvert.ConvertToBase(user.Logo);
            BackgroundColor = Color.FromHex(user.Color);
            LisMenu.BackgroundColor = Color.FromHex(user.Color);
            PopulatingMenu();
        }

        void HandleItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            try
            {
                if(e.SelectedItem == null)
                {
                    return;
                }
                var ItemSelectedMenu = (MenuLateral)e.SelectedItem;
                if (ItemSelectedMenu.id == 0)
                {
                    db.DeleteUsuario();
                    App.Current.MainPage = App.GetNavigationPage(new Views.Session.LoginPage());
                }
                else if (ItemSelectedMenu.id == 1)
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
                ((ListView)sender).SelectedItem = null;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

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
            LisMenu.ItemsSource = ListMenuLateral;
        }
    }
}
