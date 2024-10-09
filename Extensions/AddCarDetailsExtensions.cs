using CarListApp.ViewModels;
using CarListApp.Views;

namespace CarListApp.Extensions
{
    public static class AddCarDetailsExtensions
    {
        public static IServiceCollection AddCarDetails(this IServiceCollection services)
        {
            return services
                .AddTransient<CarDetailsViewModel>()
                .AddTransient<CarDetailsPage>();
        }
    }
}
