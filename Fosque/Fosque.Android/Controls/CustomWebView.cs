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
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            if (Control != null)
            {
                //webview = FindViewById<WebView>(Resource.Id.webview1);
                //webview.LoadUrl("http://www.dsclsugar.com/QuerySecure");
                //webview.SetWebViewClient(new dsclQueryWebViewClient());
                //webview.Settings.JavaScriptEnabled = true;
                //webview.Settings.UseWideViewPort = true;
                //webview.Settings.BuiltInZoomControls = true;



                //WebView.getSettings().setJavaScriptEnabled(true);
                //webview.loadUrl("your url");

                //int scale = (int)(100 * webview.getScale());
                //webview.setInitialScale(scale);

                //webview.getSettings().setLoadWithOverviewMode(true);
                //webview.getSettings().setBuiltInZoomControls(true);



                Control.Settings.DisplayZoomControls = true;
                Control.Settings.JavaScriptEnabled = true;
                int scale = (int)(100 * Control.Scale);
                Control.SetInitialScale(scale);
                Control.Settings.LoadWithOverviewMode = true;
                Control.Settings.BuiltInZoomControls = true;
            }
            base.OnElementChanged(e);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Control != null)
            {
                //webview = FindViewById<WebView>(Resource.Id.webview1);
                //webview.LoadUrl("http://www.dsclsugar.com/QuerySecure");
                //webview.SetWebViewClient(new dsclQueryWebViewClient());
                //webview.Settings.JavaScriptEnabled = true;
                //webview.Settings.UseWideViewPort = true;
                //webview.Settings.BuiltInZoomControls = true;



                //WebView.getSettings().setJavaScriptEnabled(true);
                //webview.loadUrl("your url");

                //int scale = (int)(100 * webview.getScale());
                //webview.setInitialScale(scale);

                //webview.getSettings().setLoadWithOverviewMode(true);
                //webview.getSettings().setBuiltInZoomControls(true);



                Control.Settings.DisplayZoomControls = true;
                Control.Settings.JavaScriptEnabled = true;
                int scale = (int)(100 * Control.Scale);
                Control.SetInitialScale(scale);
                Control.Settings.LoadWithOverviewMode = true;
                Control.Settings.BuiltInZoomControls = true;
            }
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
