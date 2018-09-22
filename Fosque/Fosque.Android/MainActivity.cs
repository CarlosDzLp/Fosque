﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Webkit;

namespace Fosque.Droid
{
    [Activity(Label = "Fosque", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity CurrentActivity { get; internal set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            CurrentActivity = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //CachedImageRenderer.Init(true);
            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            App.Ancho = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
            App.Alto = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            LoadApplication(new App());
        }
    }
}