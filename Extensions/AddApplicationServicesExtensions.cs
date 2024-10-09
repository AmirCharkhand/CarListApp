
namespace CarListApp.Extensions
{
    public static class AddApplicationServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddCarList()
                .AddCarDetails()
                .AddHttpClient()
                .AddSqliteConnection()
                .AddApiCarService()
                .AddSqliteCarService();
        }
    }
}
