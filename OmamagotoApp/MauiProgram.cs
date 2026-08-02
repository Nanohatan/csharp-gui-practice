using Microsoft.Extensions.Logging;

using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Features.Home;
using OmamagotoApp.Features.Products;
using OmamagotoApp.Services.Errors;
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
        // 共通サービス
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<IErrorHandler, ErrorHandler>();

        builder.Services.AddSingleton<IDialogService, DialogService>();

        builder.Services
            .AddHomeFeature()
            .AddProductEditFeature();



#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
