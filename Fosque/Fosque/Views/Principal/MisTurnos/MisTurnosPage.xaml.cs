using System;
using System.Collections.Generic;
using Fosque.ViewModels.MasterPrincipal.Turnos;
using Xamarin.Forms;

namespace Fosque.Views.Principal.MisTurnos
{
    public partial class MisTurnosPage : ContentPage
    {
        public MisTurnosPage()
        {
            InitializeComponent();
            this.BindingContext = new TurnosPageViewModel();
        }
    }
}
