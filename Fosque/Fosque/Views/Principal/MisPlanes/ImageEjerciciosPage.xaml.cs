using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Plan;
using Fosque.Models;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class ImageEjerciciosPage : ContentPage
    {
        public ImageEjerciciosPage(PlanEntrenamientoEjercicios plan)
        {
            InitializeComponent();
            this.BindingContext = new PopModalEjerciciosPageViewModel(plan);
        }
    }
}
