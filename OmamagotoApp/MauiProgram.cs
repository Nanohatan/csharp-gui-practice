using Microsoft.Extensions.Logging;

using OmamagotoApp.Pages;
using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.ViewModels;

namespace OmamagotoApp;

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

        builder.Services.AddSingleton<IDialogService, DialogService>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ProductEditPage>();
        builder.Services.AddTransient<MainViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }

}
