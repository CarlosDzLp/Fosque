using System;
using System.Collections.Generic;
using Fosque.ViewModels.MasterPrincipal.Plan;
using Xamarin.Forms;
using Fosque.Models;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class DetallePlanPage : ContentPage
    {
        public DetallePlanPage(PlanEntrenamiento plan)
        {
            InitializeComponent();
            this.BindingContext = new DetallePlanPageViewModel(plan);
        }
    }
}
