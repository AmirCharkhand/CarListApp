using CarListApp.Services.Helpers;

namespace CarListApp.Extensions
{
    public static class AddUriBuilderService
    {
        public static IServiceCollection AddUriBuilder(this IServiceCollection services)
        {
            return services.AddSingleton<UriBuilderService>();
        }
    }
}
