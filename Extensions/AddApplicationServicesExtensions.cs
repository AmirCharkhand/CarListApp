
namespace CarListApp.Extensions
{
    public static class AddApplicationServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddLoadingPage()
                .AddLoginPage()
                .AddLogoutPopUp()
                .AddCarList()
                .AddCarDetails()
                .AddHelpers()
                .AddShellController()
                .AddHttpClientFactory()
                .AddSqliteConnection()
                .AddApiCarService()
                .AddSqliteCarService()
                .AddAuthService()
                .AddUserService();
        }
    }
}
