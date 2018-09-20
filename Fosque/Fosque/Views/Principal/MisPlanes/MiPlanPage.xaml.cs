using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Plan;

namespace Fosque.Views.Principal.MisPlanes
{
    public partial class MiPlanPage : ContentPage
    {
        public MiPlanPage()
        {
            InitializeComponent();
            this.BindingContext = new MiPlanPageViewModel();
        }
    }
}
