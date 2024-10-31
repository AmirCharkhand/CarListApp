
using CarListApp.ViewModels;
using CarListApp.Views;

namespace CarListApp.Extensions
{
    public static class AddLoadingPageExtensions
    {
        public static IServiceCollection AddLoadingPage(this IServiceCollection services)
        {
            return services
                .AddTransient<LoadingPageViewModel>()
                .AddTransient<LoadingPage>();
        }

    }
}
