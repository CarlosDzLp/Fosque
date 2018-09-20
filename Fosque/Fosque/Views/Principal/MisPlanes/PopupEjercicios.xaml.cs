using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Plan;
using Fosque.Models;
using Rg.Plugins.Popup.Pages;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class PopupEjercicios : ContentPage
    {
        public PopupEjercicios(PlanEntrenamientoEjercicios plan)
        {
            InitializeComponent();
            this.BindingContext = new PopModalEjerciciosPageViewModel(plan);
        }
    }
}
