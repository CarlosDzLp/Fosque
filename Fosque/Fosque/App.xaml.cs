﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fosque.Views.Session;
using Fosque.Views.Principal;
using System.Diagnostics;
using Fosque.DbLocal;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Fosque
{
    public partial class App : Application
    {
        DbContext db = new DbContext();
        public static MasterPage MasterPageDetail { get; set; }
        public App()
        {
            InitializeComponent();
            //xmlns:views="clr-namespace:Fosque.Views"
            var result = db.GetUsuario();
            if (result !=null && result.IsRemember)
            {
                MainPage = new Views.Principal.MasterPage();
            }
            else
            {
                MainPage = GetNavigationPage(new LoginPage());
            }
        }
        public static Page GetNavigationPage(Page page)
        {
            var result = new NavigationPage(page);
            result.BarTextColor = Color.White;
            result.BarBackgroundColor = Color.FromHex("#004C3F");
            return result;
        }
        public static void MessageError(string message)
        {
            try
            {
                App.Current.MainPage.DisplayAlert("Error", message, "Aceptar");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public static void MessageSuccess(string message)
        {
            try
            {
                App.Current.MainPage.DisplayAlert("Fosque", message, "Aceptar");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
