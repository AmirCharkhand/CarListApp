﻿using CarListApp.Controls;
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
                    Shell.Current.Items.Add(new FlyoutItem()
                    {
                        Title = "Cars List managment",
                        Route = nameof(MainPage),
                        FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                        Items =
                        {
                            new ShellContent()
                            {
                                Icon = "dotnet_bot.png",
                                Title = "Admin page_1",
                                ContentTemplate = new DataTemplate(typeof(MainPage)),
                            }
                        }
                    });
                    break;
                case Enums.UserRole.User:
                    Shell.Current.Items.Add(new FlyoutItem()
                    {
                        Title = "Cars List",
                        Route = nameof(MainPage),
                        FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                        Items =
                        {
                            new ShellContent()
                            {
                                Icon = "dotnet_bot.png",
                                Title = "User page_1",
                                ContentTemplate = new DataTemplate(typeof(MainPage)),
                            }
                        }
                    });
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void BuildLogoutOption()
        {
            Shell.Current.Items.Add(new FlyoutItem()
            {
                Title = "Log out",
                Route = nameof(LogoutPopup),
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsSingleItem,
                Items =
                {
                    new ShellContent()
                    {
                        Icon = "dotnet_bot.png",
                        Title = "Logout",
                        ContentTemplate = new DataTemplate(typeof(LogoutPopup))
                    }
                }
            });
        }
    }
}
