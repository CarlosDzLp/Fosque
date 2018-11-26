using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.MisReservas;

namespace Fosque.Views.Principal.MisReservas
{
    public partial class MisReservasPage : ContentPage
    {
        public MisReservasPage()
        {
            InitializeComponent();
            this.BindingContext = new ReservasPageViewModel();
        }
    }
}
