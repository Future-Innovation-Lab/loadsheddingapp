﻿using CommunityToolkit.Maui;
using LoadSheddingApp.Configuration;
using LoadSheddingApp.Services;
using LoadSheddingApp.Services.Interfaces;
using LoadSheddingApp.ViewModels;
using LoadSheddingApp.Views;
using Microsoft.Extensions.Logging;

namespace LoadSheddingApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //    builder.Services.AddTransient<ILoggingService, loggingService>();
            //    builder.Services.AddTransient<ISettingsService, SettingsService>();
            builder.RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
              mauiAppBuilder.Services.AddTransient<IAiAssistant, LoadsheddingAiAssistant>();
              mauiAppBuilder.Services.AddTransient<ISettings, ConstantSettings>();

            // More services registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoadsheddingQuestionViewModel>();
            mauiAppBuilder.Services.AddSingleton<LoadsheddingAnswerViewModel>();

            // More view-models registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoadsheddingQuestionPage>();
            mauiAppBuilder.Services.AddSingleton<LoadsheddingAnswerPage>();

            // More views registered here.

            return mauiAppBuilder;
        }
    }
}
