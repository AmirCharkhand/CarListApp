
using CarListApp.Services.Helpers;

namespace CarListApp.Services.Core
{
    public class ShellController(FlyoutMenuBuilderService flyoutMenuBuilder, UserService userService)
    {
        private FlyoutMenuBuilderService _flyoutMenuBuilder = flyoutMenuBuilder;
        private UserService _userService = userService;

        private string UserId { get; set; } = string.Empty;

        public async Task SetFlyout()
        {
            var currentUser = await _userService.GetUserInfo();
            if (string.Equals(UserId,currentUser.Id))
                return;

            UserId = currentUser.Id;
            var flyoutMenu = _flyoutMenuBuilder.BuildMenu(currentUser);
            Shell.Current.Items.Clear();
            Shell.Current.FlyoutHeader = flyoutMenu.FlyoutHeader;
            foreach (var shellContent in flyoutMenu.Contents)
            {
                Shell.Current.Items.Add(shellContent);
            }
        }
    }
}
