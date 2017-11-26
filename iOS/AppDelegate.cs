using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.Toasts;
using SuaveControls.FloatingActionButton.iOS.Renderers;
using UIKit;
using Xamarin.Forms;

namespace firenotes.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            DependencyService.Register<ToastNotification>();
            ToastNotification.Init();

            FloatingActionButtonRenderer.InitRenderer();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
