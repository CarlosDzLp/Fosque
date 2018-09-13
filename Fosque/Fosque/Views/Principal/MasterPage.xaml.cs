using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Fosque.Views.Principal
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            App.MasterPageDetail = this;
        }
    }
}
