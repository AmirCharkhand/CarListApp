
using CarListApp.ViewModels;
using CarListApp.Views;

namespace CarListApp.Extensions
{
    public static class AddLoginPageExtensions
    {
        public static IServiceCollection AddLoginPage(this IServiceCollection services)
        {
            return services
                .AddTransient<LoginPageViewmodel>()
                .AddTransient<LoginPage>();
        }
    }
}
