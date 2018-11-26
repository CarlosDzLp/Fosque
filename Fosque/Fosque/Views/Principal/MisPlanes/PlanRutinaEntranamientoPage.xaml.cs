using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Plan;
using Fosque.Models;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class PlanRutinaEntranamientoPage : ContentPage
    {
        public PlanRutinaEntranamientoPage(SubPlanEntrenamiento subplan,string idPlan)
        {
            InitializeComponent();
            this.BindingContext = new PlanRutinaEntrenamientoPageViewModel(subplan,idPlan);
        }
    }
}
