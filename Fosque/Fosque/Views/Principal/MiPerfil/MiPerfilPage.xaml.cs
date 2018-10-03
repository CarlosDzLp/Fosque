using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Fosque.ViewModels.MasterPrincipal.Perfil;

namespace Fosque.Views.Principal.MiPerfil
{
    public partial class MiPerfilPage : ContentPage
    {
        public MiPerfilPage()
        {
            InitializeComponent();
            this.BindingContext = new PerfilViewModel();
        }
    }
}
