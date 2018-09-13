using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal;

namespace Fosque.Views.Principal
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            this.BindingContext = new MenuPageViewModel();
        }
    }
}
