using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Plan;
using Fosque.Models;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class PopModalEjerciciosPage : ContentPage
    {
        public PopModalEjerciciosPage(PlanEntrenamientoEjercicios planEntrenamiento)
        {
            InitializeComponent();
            this.BindingContext = new PopModalEjerciciosPageViewModel(planEntrenamiento);
        }
    }
}
