﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Maui.TouchEffect.Hosting;
namespace MentalHealthApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiTouchEffect()
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                        handlers.AddHandler(typeof(Entry), typeof (MentalHealthApp.Platforms.Android.MyEntryHandler));
                        handlers.AddHandler(typeof(Editor), typeof (MentalHealthApp.Platforms.Android.MyEditorHandler));
#endif

                }
                )
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MentalHealthAppDB>();
            builder.Services.AddTransient<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
