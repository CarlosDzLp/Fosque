using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.Session;

namespace Fosque.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginPageViewModel();
        }
    }
}
