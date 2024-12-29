using CarListApp.Services.Helpers;

namespace CarListApp.Extensions
{
    public static class AddHelperServices
    {
        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            return services
                .AddSingleton<UriBuilderService>()
                .AddTransient<FlyoutMenuBuilderService>();
        }
    }
}
