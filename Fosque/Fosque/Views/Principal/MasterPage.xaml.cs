using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.DbLocal;

namespace Fosque.Views.Principal
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            App.MasterPageDetail = this;
            var user = new DbContext();
            var color = user.GetUsuario();
            Master = new MenuPage();
            var navigation = new NavigationPage(new HomePage());
            navigation.BarTextColor = Color.White;
            navigation.BarBackgroundColor = Color.FromHex(color.Color);
            Detail = navigation;
        }
    }
}
