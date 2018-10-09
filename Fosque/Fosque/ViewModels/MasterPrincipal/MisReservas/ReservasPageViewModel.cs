using System;
using Fosque.ViewModels.Base;
using System.Collections.ObjectModel;
using Fosque.Models;
using System.Diagnostics;
using Fosque.Services;
using Fosque.DbLocal;
using Fosque.Helpers;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Fosque.ViewModels.MasterPrincipal.Turnos;

namespace Fosque.ViewModels.MasterPrincipal.MisReservas
{
    public class ReservasPageViewModel : BindableBase
    {
        #region Properties
        private ObservableCollection<HistorialReservaModel> listHistorialReserva;
        public ObservableCollection<HistorialReservaModel> ListhistorialReserva
        {
            get { return listHistorialReserva; }
            set { SetProperty(ref listHistorialReserva, value); }
        }
        private HistorialReservaModel selectedItemHistorial;
        public HistorialReservaModel SelectedItemHistorial
        {
            get { return selectedItemHistorial; }
            set
            {
                if (selectedItemHistorial != value)
                {
                    SetProperty(ref selectedItemHistorial, value);
                    OnTapSelectedItem();
                }
            }
        }

        private bool isBussy;
        public bool IsBussy
        {
            get { return isBussy; }
            set
            {
                SetProperty(ref isBussy, value);
            }
        }
        #endregion

        #region Constructor
        public ReservasPageViewModel()
        {
            Loadhistorialreserva();
            IsBusyCommand = new Command(Loadhistorialreserva);
        }
        #endregion

        #region Methods
        private async void Loadhistorialreserva()
        {
            try
            {
                IsBussy = true;
                ListhistorialReserva = new ObservableCollection<HistorialReservaModel>();
                ListhistorialReserva.Clear();
                ServiceClient client = new ServiceClient();
                var db = new DbContext();
                var user = db.GetUsuario();
                var response = await client.GetListAllWithParam<List<HistorialReservaModel>>(Configuration.BaseUrl, $"pnl/spapp/wsturnero_mis_reservas?client={user.Client}&socio={user.IdUser}");
                IsBussy = false;
                if (response != null)
                {
                    if (response.Count > 0)
                    {
                        foreach (var item in response.OrderByDescending(c=>c.Fecha))
                        {
                            ListhistorialReserva.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                IsBussy = false;
                Debug.WriteLine(ex.Message);
            }
        }

        private async void OnTapSelectedItem()
        {
            try
            {
                if (SelectedItemHistorial != null)
                {
                    if (SelectedItemHistorial.Estado == "1")
                    {
                        var action = await App.Current.MainPage.DisplayAlert("Reserva", "¿Desea anular la reserva?","Anular","Cancelar");
                        //se puede anular la reserva
                        if(action)
                        {
                            ServiceClient client = new ServiceClient();
                            var db = new DbContext();
                            var user = db.GetUsuario();
                            var response = await client.GetListAllWithParam<ResponseMessage>(Configuration.BaseUrl, $"pnl/spapp/wsturnero_reserva_del?client={user.Client}&id={SelectedItemHistorial.IdReserva}");
                            if (response.StatusCode == 200)
                            {
                                App.MessageSuccess(response.Mensaje);
                            }
                            else
                            {
                                App.MessageError(response.Mensaje);
                            }
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Reserva", "se dio en cancelar", "Aceptar");
                        }
                    }
                    Loadhistorialreserva();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Command
        public ICommand IsBusyCommand { set; get; }
        #endregion

    }
}
