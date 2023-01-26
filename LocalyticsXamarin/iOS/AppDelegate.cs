using System;
using Foundation;
using UIKit;
using LocalyticsSample.Shared;
using LocalyticsXamarin.IOS;
using System.Diagnostics;
using MapKit;

namespace LocalyticsSample.IOS
{
	[Register ("AppDelegate")]
	public class AppDelegate : MauiUIApplicationDelegate
    {
        private const string DevORViOSKey = "4f2b387acc0e8a7f80ae160-e3aa65be-e1fd-11e5-7ff8-0086bc74ca0f";

        protected override MauiApp CreateMauiApp() => iOS.MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Localytics Integrate
            Localytics.LoggingEnabled = true;
            Localytics.Integrate(DevORViOSKey, launchOptions ?? new NSDictionary());

            // Register for remote notifications
            var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                new NSSet());
            UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            return base.FinishedLaunching(application, launchOptions);
        }

        [Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
        public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            Console.WriteLine("Push Token Registered " + deviceToken.DebugDescription);
            Localytics.SetPushToken(deviceToken);
        }

        [Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
        public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            Console.WriteLine("Failed to Register for Notifications " + error);
        }
    }
}
