using System;
using BigTed;
using Fosque.Dependency;
using Fosque.iOS.Dependency;

[assembly:Xamarin.Forms.Dependency(typeof(Progress))]
namespace Fosque.iOS.Dependency
{
    public class Progress : IProgressDialog
    {
        public void ProgressDialogHide()
        {
            BTProgressHUD.Dismiss();
        }

        public void ProgressDialogShow()
        {
            BTProgressHUD.Show("Cargando...", -1, ProgressHUD.MaskType.Black);
        }
    }
}
