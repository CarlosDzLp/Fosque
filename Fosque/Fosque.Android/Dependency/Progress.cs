using System;
using Fosque.Dependency;
using AndroidHUD;
using Fosque.Droid.Dependency;

[assembly:Xamarin.Forms.Dependency(typeof(Progress))]
namespace Fosque.Droid.Dependency
{
    public class Progress : IProgressDialog
    {
        public void ProgressDialogHide()
        {
            AndHUD.Shared.Dismiss();
        }

        public void ProgressDialogShow()
        {
            AndHUD.Shared.Show(MainActivity.CurrentActivity, "Cargando...", -1, MaskType.Black, null, null, true, null);
        }
    }
}
