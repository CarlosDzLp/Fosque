using System;
using Fosque.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using Fosque.Models;
using System.Linq;
using System.IO;

namespace Fosque.ViewModels.MasterPrincipal.Plan
{
    public class PopModalEjerciciosPageViewModel : BindableBase
    {
        #region Properties
        private bool isImage;
        public bool IsImage
        {
            get { return isImage; }
            set { SetProperty(ref isImage, value); }
        }
        private bool isNotImage;
        public bool IsNotImage
        {
            get { return isNotImage; }
            set { SetProperty(ref isNotImage, value); }
        }

        private PlanEntrenamientoEjercicios planejerccios;
        public PlanEntrenamientoEjercicios Plan
        {
            get { return planejerccios; }
            set { SetProperty(ref planejerccios, value); }
        }
        #endregion

        #region Constructor
        public PopModalEjerciciosPageViewModel(PlanEntrenamientoEjercicios plan)
        {
            //webview solo acepta videos y .gif, si se quiere mostrar image se debe mostrar en un Image 
            //si la extencion de imagen no esta en images, hay que agregar las extenciones de imagnes que se requiera
            Plan = new PlanEntrenamientoEjercicios();
            if(string.IsNullOrEmpty(plan.Video))
            {
                IsImage = true;
                IsNotImage = false;
                plan.Video = "imagenotfound.png";
            }
            else
            {
                string[] images = { ".png", ".jpg", ".jpeg" };
                var result = images.Contains(Path.GetExtension(plan.Video));
                if (result)
                {
                    IsImage = true;
                    IsNotImage = false;
                }
                else
                {
                    IsImage = false;
                    IsNotImage = true;
                }
            }
            Plan = plan;
            ClosePageCommand = new Command(ClosePageCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand ClosePageCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void ClosePageCommandExecuted()
        {
            App.MasterPageDetail.IsPresented = false;
            App.MasterPageDetail.Detail.Navigation.PopModalAsync();
        }
        #endregion
    }
}
