﻿using GuiaTuristicaApp.Services;
using Microsoft.Extensions.Logging;

namespace GuiaTuristicaApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<IAPIService, APIService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}