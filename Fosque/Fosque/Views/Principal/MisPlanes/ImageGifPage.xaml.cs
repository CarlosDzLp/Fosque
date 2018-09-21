using System;
using System.Collections.Generic;
using Fosque.Models;
using Fosque.ViewModels.MasterPrincipal.Plan;
using Xamarin.Forms;
using System.Diagnostics;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class ImageGifPage : ContentPage
    {
        public ImageGifPage(PlanEntrenamientoEjercicios plan)
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new PopModalEjerciciosPageViewModel(plan);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
