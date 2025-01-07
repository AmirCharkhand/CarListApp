
using CarListApp.Services.Core;

namespace CarListApp.Extensions
{
    public static class AddShellControllerServiceExtension
    {
        public static IServiceCollection AddShellController(this IServiceCollection services)
        {
            return services.AddSingleton<ShellController>();
        }
    }
}
