
namespace CarListApp.Extensions
{
    public static class AddApplicationServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddLoadingPage()
                .AddLoginPage()
                .AddCarList()
                .AddCarDetails()
                .AddUriBuilder()
                .AddHttpClient()
                .AddSqliteConnection()
                .AddApiCarService()
                .AddSqliteCarService();
        }
    }
}
