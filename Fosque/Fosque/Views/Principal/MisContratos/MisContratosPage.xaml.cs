using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Contratos;

namespace Fosque.Views.Principal.MisContratos
{
    public partial class MisContratosPage : ContentPage
    {
        public MisContratosPage()
        {
            InitializeComponent();
            this.BindingContext = new ContratosViewModel();
        }
    }
}
