using ResizeMAUI.Application.Maui.Pages;
using ResizeMAUI.Models.Factories;
using ResizeMAUI.ViewModels;

namespace ResizeMAUI.Application.Maui
{
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
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseVersionTracking();
                });

            IServiceCollection services = builder.Services;
            services.AddScoped<IPageLayoutFactory, PageLayoutFactory>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainPage>();

            return builder.Build();
        }
    }
}
