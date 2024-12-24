
using CarListApp.Services.Core;

namespace CarListApp.Extensions
{
    public static class AddAuthServiceExtension
    {
        public static IServiceCollection AddAuthService(this IServiceCollection services)
        {
            return services.AddSingleton<AuthService>();
        }
    }
}
