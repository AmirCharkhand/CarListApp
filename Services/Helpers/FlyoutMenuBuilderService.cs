using CarListApp.Controls;
using CarListApp.Models;
using CarListApp.Services.Core;
using CarListApp.Views;

namespace CarListApp.Services.Helpers
{
    public class FlyoutMenuBuilderService(UserService userService)
    {
        private readonly UserService _userService = userService;

        public async Task BuildMenu()
        {
            var userInfo = await _userService.GetUserInfo();
            Shell.Current.Items.Clear();
            Shell.Current.FlyoutHeader = new FlyoutHeader(userInfo);

            BuildMenuBaseOnUserRole(userInfo);
            BuildLogoutOption();
        }

        private void BuildMenuBaseOnUserRole(UserInfoModel userInfo)
        {
            switch (userInfo.Role)
            {
                case Enums.UserRole.Admin:
                    Shell.Current.Items.Add(new ShellContent()
                    {
                        Title = "Cars List managment",
                        Icon = "dotnet_bot.png",
                        ContentTemplate = new DataTemplate(typeof(MainPage))
                    });
                    break;
                case Enums.UserRole.User:
                    Shell.Current.Items.Add(new ShellContent()
                    {
                        Title = "Cars List",
                        Icon = "dotnet_bot.png",
                        ContentTemplate = new DataTemplate(typeof(MainPage))
                    });
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void BuildLogoutOption()
        {
            Shell.Current.Items.Add(new ShellContent()
            {
                Title = "Log Out",
                Icon = "dotnet_bot.png",
                ContentTemplate = new DataTemplate(typeof(LogoutPopup))
            });
        }
    }
}
