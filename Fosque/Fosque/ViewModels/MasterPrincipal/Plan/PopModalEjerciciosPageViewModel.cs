using System;
using Fosque.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using Fosque.Models;
using System.Linq;
using System.IO;
using System.Diagnostics;
using Rg.Plugins.Popup.Services;

namespace Fosque.ViewModels.MasterPrincipal.Plan
{
    public class PopModalEjerciciosPageViewModel : BindableBase
    {
        #region Properties
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
            try
            {
                Plan = new PlanEntrenamientoEjercicios();
                Plan = plan;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
