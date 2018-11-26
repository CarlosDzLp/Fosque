using System;
using System.Collections.Generic;
using Fosque.ViewModels.MasterPrincipal.Turnos;
using Xamarin.Forms;

namespace Fosque.Views.Principal.MisTurnos
{
    public partial class DetailTurnosPage : ContentPage
    {
        public DetailTurnosPage(string Id)
        {
            InitializeComponent();
            this.BindingContext = new DetailTurnosPageViewModel(Id);
        }
    }
}
