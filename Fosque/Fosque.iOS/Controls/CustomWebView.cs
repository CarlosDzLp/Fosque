using System;
using Fosque.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(WebView),typeof(CustomWebView))]
namespace Fosque.iOS.Controls
{
    public class CustomWebView : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            var view = (UIWebView)NativeView;
            view.ScrollView.ScrollEnabled = true;
            view.ScalesPageToFit = true;
        }
    }
}
