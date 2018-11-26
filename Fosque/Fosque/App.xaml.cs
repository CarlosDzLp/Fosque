using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fosque.Views.Session;
using Fosque.Views.Principal;
using System.Diagnostics;
using Fosque.DbLocal;
using Com.OneSignal;
//using Com.OneSignal;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Fosque
{
    public partial class App : Application
    {
        public static int Alto { get; set; }
        public static int Ancho { get; set; }
        DbContext db = new DbContext();

        public static string ColorApp { get; set; }
        public static MasterPage MasterPageDetail { get; set; }
        public App()
        {
            InitializeComponent();
            var result = db.GetUsuario();
            if (result !=null && result.IsRemember)
            {
                MainPage = new Views.Principal.MasterPage();
            }
            else
            {
                MainPage = GetNavigationPage(new LoginPage());
            }
            //OneSignal.Current.StartInit("90605ae0-321f-4bfe-b9e9-50a1776f5291").EndInit();
            OneSignal.Current.IdsAvailable(IdsAvailable);
        }
        public async void IdsAvailable(string playerId,string pushToken)
        {
            var db = new DbContext();
            var token = db.GetToken();
            if(token != null)
            {
                var table = new TableToken();
                table.PlayerID = playerId;
                table.Token = pushToken;
                db.UpdateToken(table);
            }
            else
            {
                var table = new TableToken();
                table.PlayerID = playerId;
                table.Token = pushToken;
                db.InsertToken(table);
            }
        }
        public static Page GetNavigationPage(Page page)
        {
            var result = new NavigationPage(page);
            result.BarTextColor = Color.White;
            result.BarBackgroundColor = Color.FromHex("#EC018E");
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
