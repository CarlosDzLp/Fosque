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
                var html = new HtmlWebViewSource();
                html.Html = Helpers.HtmlHelper.getHtml(plan.Video, App.Ancho, App.Alto);
                WebViewGif.Source = html;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
