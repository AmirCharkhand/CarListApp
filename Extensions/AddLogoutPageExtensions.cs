using CarListApp.ViewModels;
using CarListApp.Views;

namespace CarListApp.Extensions
{
    public static class AddLogoutPageExtensions
    {
        public static IServiceCollection AddLogoutPopUp(this IServiceCollection services)
        {
            return services
                .AddTransient<LogoutPopupViewModel>()
                .AddTransient<LogoutPopup>();
        }
    }
}
