using CarListApp.Services.Core;

namespace CarListApp.Extensions
{
    public static class AddCarServiceExtensions
    {
        public static IServiceCollection AddSqliteCarService (this IServiceCollection services)
        {
            return services.AddSingleton<SqliteCarService>();
        }

        public static IServiceCollection AddApiCarService(this IServiceCollection services)
        {
            return services.AddTransient<ApiCarService>();
        }
    }
}
