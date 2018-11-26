using Fosque.Dependency;
using Fosque.Services;
using Fosque.Models;
using Fosque.Helpers;
using Fosque.ViewModels.Base;
using Xamarin.Forms;
using System;
using System.Diagnostics;
using Fosque.DbLocal;
using ZXing.Net.Mobile.Forms;

namespace Fosque.ViewModels.MasterPrincipal.Contratos
{
    public class ContratosViewModel : BindableBase
    {
        #region Properties
        private ContratosModel contratos;
        public ContratosModel Contratos
        {
            get { return contratos; }
            set { SetProperty(ref contratos, value); }
        }
        private ZXingBarcodeImageView qr;
        public ZXingBarcodeImageView QR
        {
            get { return qr; }
            set { SetProperty(ref qr, value); }
        }
        private bool isVisibleContratos;
        public bool IsVisibleContratos
        {
            get { return isVisibleContratos; }
            set { SetProperty(ref isVisibleContratos, value); }
        }
        private bool isVisibleNoContratos;
        public bool IsVisibleNoContratos
        {
            get { return isVisibleNoContratos; }
            set { SetProperty(ref isVisibleNoContratos, value); }
        }
        #endregion

        #region Constructor
        public ContratosViewModel()
        {
            LoadContratos();
        }
        #endregion

        #region Methods
        private async void LoadContratos()
        {
            try
            {

                DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                ServiceClient client = new ServiceClient();
                var db = new DbContext();
                var user = db.GetUsuario();
                var response = await client.GetListAllWithParam<ContratosModel>(Configuration.BaseUrl, $"pnl/api/get_membresias_socioApp?client={user.Client}&socio={user.DNI}");
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                if(response!=null)
                {
                    Contratos = response;
                    Contratos.PhotoConvert = ImageConvert.ConvertToBase(response.Photo);
                    QR = new ZXingBarcodeImageView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                    };
                    QR.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                    QR.BarcodeOptions.Width = 350;
                    QR.BarcodeOptions.Height = 350;
                    QR.BarcodeValue = response.Contrato;
                    Contratos.VigenciaContrato = response.Vigenciad + " al " + response.Vigenciah;
                    if(string.IsNullOrEmpty(response.Actividad))
                    {
                        IsVisibleContratos = false;
                        IsVisibleNoContratos = true;
                    }
                    else
                    {
                        IsVisibleContratos = true;
                        IsVisibleNoContratos = false;
                    }
                }
                else
                {
                    App.MessageError("No se pudo encontrar el contrato");
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
