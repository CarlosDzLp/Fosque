using System;
using Fosque.ViewModels.Base;
using Fosque.DbLocal;
using Xamarin.Forms;
using Fosque.Services;
using Fosque.Helpers;
using Fosque.Models;
using System.Diagnostics;
using Fosque.Dependency;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fosque.ViewModels.MasterPrincipal
{
    public class HomePageViewModel : BindableBase
    {
        DbContext db = new DbContext();
        #region Properties
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private ObservableCollection<HomeModel> listPublicidad;
        public ObservableCollection<HomeModel> ListPublicidad
        {
            get { return listPublicidad; }
            set { SetProperty(ref listPublicidad, value); }
        }
        #endregion

        #region Contructor
        public HomePageViewModel()
        {
            var user = db.GetUsuario();
            Title = user.NombreApp;
            loadHome();
            IsBusyCommand = new Command(loadHome);
        }
        #endregion

        #region Methods
        private async void loadHome()
        {
            try
            {
                IsBusy = true;
                ListPublicidad = new ObservableCollection<HomeModel>();
                listPublicidad.Clear();
                var user = db.GetUsuario();
                ServiceClient client = new ServiceClient();
                var response = await client.GetListAllWithParam<List<HomeModel>>(Configuration.BaseUrl, $"pnl/spapp/ws_home?client={user.Client}&ptovta={user.Sede}");
                if (response != null)
                {
                    if (response.Count > 0)
                    {
                        foreach (var item in response)
                        {
                            item.ImagenConvert = Helpers.ImageConvert.ConvertToBase(item.Imagen);
                            ListPublicidad.Add(item);
                        }
                    }
                }
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                IsBusy = false;
                Debug.WriteLine(ex.Message);
            }
        }




        #endregion

        #region Command
        public ICommand IsBusyCommand { get; set; }
        #endregion

    }
}
