using ClonePizzaMaui.Pages;
using ClonePizzaMaui.Services;
using ClonePizzaMaui.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace ClonePizzaMaui
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
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            AddPizzaService(builder.Services);

            return builder.Build();
        }

        private static IServiceCollection AddPizzaService(IServiceCollection services)
        {
            services.AddSingleton<PizzaService>();
            services.AddSingleton<HomePage>()
                .AddSingleton<HomeViewModel>();
            //services.AddSingletonWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
            services.AddTransientWithShellRoute<AllPizzasPage, AllPizzasViewModel>(nameof(AllPizzasPage));
            //services.AddTransientWithShellRoute<DetailPage, DetailViewModel>(nameof(DetailPage));
            services.AddSingleton<DetailViewModel>();
            services.AddTransient<DetailPage>();
            services.AddSingleton<CartViewModel>();
            services.AddTransient<CartPage>();

            return services;
        }
        // aggiungere un servizio al contenitore di servizi durante la configurazione della dependency injection
        // IServiceCollection rappresenta il contenitore di servizi che mappa le interfacce di servizio alle
        // loro implementazioni concrete.
        // restituisce l'oggetto IServiceCollection aggiornato, consentendo l'encapsulamento della logica
        // di configurazione dei servizi e seguendo il principio di inversione delle dipendenze.
    }
}
