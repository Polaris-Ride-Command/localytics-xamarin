using System;
using Android.App;
using Android.Runtime;

namespace LocalyticsSample.Android
{
    [Application]
    public class LocalyticsAutoIntegrateApplication : MauiApplication
    {
        public LocalyticsAutoIntegrateApplication(IntPtr handle, JniHandleOwnership ownerShip)
            : base(handle, ownerShip)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        override public void OnCreate()
        {
            base.OnCreate();

#if DEBUG
            var localytics = LocalyticsXamarin.Shared.LocalyticsSDK.SharedInstance;
			localytics.LoggingEnabled = true;
#endif

            LocalyticsXamarin.Android.Localytics.AutoIntegrate(this);

        }
    }
}
