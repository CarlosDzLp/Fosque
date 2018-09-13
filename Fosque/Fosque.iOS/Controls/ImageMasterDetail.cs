using System;
using Fosque.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Fosque.Views.Principal;
using UIKit;
using CoreGraphics;

[assembly:ExportRenderer(typeof(MasterPage),typeof(ImageMasterDetail))]
namespace Fosque.iOS.Controls
{
    public class ImageMasterDetail : PhoneMasterDetailRenderer
    {
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            if (!(Element is MasterPage mdp)) return;
            if (!(Platform.GetRenderer(mdp.Detail) is UINavigationController nc)) return;

            UIButton btn = new UIButton(UIButtonType.Custom);
            btn.Frame = new CGRect(0, 0, 50, 44);
            var img = UIImage.FromFile("menu.png");
            btn.SetTitle(string.Empty, UIControlState.Normal);
            btn.SetImage(img, UIControlState.Normal);
            btn.TouchUpInside += (sender, e) => mdp.IsPresented = true;
            nc.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.White
            };

            //nc.NavigationBar.BarTintColor = Color.FromHex("#52A7E0").ToUIColor();

            var lbbi = new UIBarButtonItem(btn);
            nc.NavigationBar.TopItem.LeftBarButtonItem = lbbi;
        }
    }
}
