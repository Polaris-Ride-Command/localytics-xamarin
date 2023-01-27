using System;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Storage;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.Shared;
using LocalyticsSample.Shared;

namespace LocalyticsSample.Android
{
	public static class MauiProgram
	{
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<LocalyticsSample.Shared.App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<LandingPage>();

            builder.Services.AddSingleton<ILocalytics, LocalyticsXamarinForms>();
            builder.Services.AddSingleton<IPlatform, LocalyticsXamarinForms>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

