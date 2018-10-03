using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal;

namespace Fosque.Views.Principal
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new HomePageViewModel();
        }
    }
}
