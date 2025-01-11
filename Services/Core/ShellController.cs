
using CarListApp.Services.Helpers;

namespace CarListApp.Services.Core
{
    public class ShellController
    {
        private string UserId { get; set; } = string.Empty;

        public async Task SetFlyout(UserService userService, FlyoutMenuBuilderService flyoutMenuBuilder)
        {
            var currentUser = await userService.GetUserInfo();
            if (string.Equals(UserId,currentUser.Id))
                return;

            UserId = currentUser.Id;
            var flyoutMenu = flyoutMenuBuilder.BuildMenu(currentUser);
            Shell.Current.Items.Clear();
            Shell.Current.FlyoutHeader = flyoutMenu.FlyoutHeader;
            foreach (var shellContent in flyoutMenu.Contents)
            {
                Shell.Current.Items.Add(shellContent);
            }
        }
    }
}
