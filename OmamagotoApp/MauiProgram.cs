using Microsoft.Extensions.Logging;

using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Features.Home;
using OmamagotoApp.Features.Products;
using OmamagotoApp.Services.Errors;
using OmamagotoApp.Services.Navigation;
using OmamagotoApp.Services.Database;
using Microsoft.Maui.Handlers;
namespace OmamagotoApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
        {
#if ANDROID
    handler.PlatformView.Background = null;

#elif IOS || MACCATALYST
            handler.PlatformView.BorderStyle =
                UIKit.UITextBorderStyle.None;
#endif
        });
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        // 共通サービス
        builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IErrorHandler, ErrorHandler>();


        builder.Services
            .AddHomeFeature()
            .AddProductFeature();



#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
