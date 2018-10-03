using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Configuracion;

namespace Fosque.Views.Principal.MiConfiguarion
{
    public partial class MiConfiguracionPage : ContentPage
    {
        public MiConfiguracionPage()
        {
            InitializeComponent();
            this.BindingContext = new ConfiguracionPageViewModel();
        }
    }
}
