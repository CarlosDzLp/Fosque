using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Fosque.Droid.Controls;
using Android.Content;
using System.ComponentModel;

[assembly:ExportRenderer(typeof(WebView),typeof(CustomWebView))]
namespace Fosque.Droid.Controls
{
    public class CustomWebView : WebViewRenderer
    {
        public CustomWebView(Context context) : base(context)
        {
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Control != null)
            {
                Control.Settings.BuiltInZoomControls = true;
                Control.Settings.DisplayZoomControls = true;
            }
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
