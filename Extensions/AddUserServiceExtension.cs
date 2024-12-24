
using CarListApp.Services.Core;

namespace CarListApp.Extensions
{
    public static class AddUserServiceExtension
    {
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            return services.AddSingleton<UserService>();
        }
    }
}
