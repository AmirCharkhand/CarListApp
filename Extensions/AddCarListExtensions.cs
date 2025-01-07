
using CarListApp.ViewModels;
using CarListApp.Views;

namespace CarListApp.Extensions
{
    public static class AddCarListExtensions
    {
        public static IServiceCollection AddCarList(this IServiceCollection services)
        {
            return services
                .AddSingleton<CarListViewModel>()
                .AddSingleton<CarListPage>();
        }
    }
}
