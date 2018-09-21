using System;
using System.Collections.Generic;
using Fosque.Models;
using Fosque.ViewModels.MasterPrincipal.Plan;
using Xamarin.Forms;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class ImageGifPage : ContentPage
    {
        public ImageGifPage(PlanEntrenamientoEjercicios plan)
        {
            InitializeComponent();
            this.BindingContext= new PopModalEjerciciosPageViewModel(plan);
        }
    }
}
