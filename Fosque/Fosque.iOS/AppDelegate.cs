﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using Com.OneSignal;

namespace Fosque.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            //statusBar.BackgroundColor = UIColor.fro();
            Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            ImageCircle.Forms.Plugin.iOS.ImageCircleRenderer.Init();
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            OneSignal.Current.StartInit("90605ae0-321f-4bfe-b9e9-50a1776f5291").EndInit();
            LoadApplication(new App());
            App.Alto = (int)UIScreen.MainScreen.Bounds.Height;
            App.Ancho = (int)UIScreen.MainScreen.Bounds.Width;
                //new Size(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
            return base.FinishedLaunching(app, options);
        }
    }
}
