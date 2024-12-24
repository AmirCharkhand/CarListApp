using CarListApp.Handlers;

namespace CarListApp.Extensions
{
    public static class AddHttpClientExtension
    {
        public static IServiceCollection AddHttpClientFactory(this IServiceCollection services)
        {
            services
                .AddTransient<AuthenticationDelegatingHandler>();

            services
                .AddHttpClient("UnAuthorized");

            services
                .AddHttpClient("Authorized")
                .AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            return services;
        }
    }
}