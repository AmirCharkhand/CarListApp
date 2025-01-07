using CarListApp.Controls;
using CarListApp.Models;
using CarListApp.Views;

namespace CarListApp.Services.Helpers
{
    public class FlyoutMenuBuilderService
    {
        public FlyoutMenuModel BuildMenu(UserInfoModel userInfo)
        {
            var header = new FlyoutHeader(userInfo);
            List<ShellContent> shellContents = BuildMenuBaseOnUserRole(userInfo);
            shellContents.Add(BuildLogoutOption());

            return new FlyoutMenuModel(header, shellContents);
        }

        private List<ShellContent> BuildMenuBaseOnUserRole(UserInfoModel userInfo)
        {
            var shellContents = new List<ShellContent>();

            switch (userInfo.Role)
            {
                case Enums.UserRole.Admin:
                    shellContents.Add(new ShellContent()
                    {
                        Title = "Cars List managment",
                        Icon = "dotnet_bot.png",
                        ContentTemplate = new DataTemplate(typeof(CarListPage))
                    });
                    break;
                case Enums.UserRole.User:
                    shellContents.Add(new ShellContent()
                    {
                        Title = "Cars List",
                        Icon = "dotnet_bot.png",
                        ContentTemplate = new DataTemplate(typeof(CarListPage))
                    });
                    break;
                default:
                    throw new NotImplementedException();
            }

            return shellContents;
        }

        private ShellContent BuildLogoutOption()
        {
            return new ShellContent()
            {
                Title = "Log Out",
                Icon = "dotnet_bot.png",
                ContentTemplate = new DataTemplate(typeof(LogoutPopup))
            };
        }
    }
}
