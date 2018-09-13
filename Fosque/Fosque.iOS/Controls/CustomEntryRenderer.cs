using System;
using Xamarin.Forms;
using Fosque.iOS.Controls;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;

[assembly:ExportRenderer(typeof(Entry),typeof(CustomEntryRenderer))]
namespace Fosque.iOS.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = Element;
                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));

                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(5);
                // Thickness of the Border Color  
                Control.Layer.BorderColor = Color.White.ToCGColor();
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = 2;
                Control.ClipsToBounds = true;
            }
        }
    }
}
