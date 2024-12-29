
using CarListApp.Services.Core;
using CarListApp.Services.Helpers;
using CarListApp.Views;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels
{
    public partial class LoadingPageViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly FlyoutMenuBuilderService _flyoutMenuBuilder;

        public LoadingPageViewModel(AuthService authService, FlyoutMenuBuilderService flyoutMenuBuilder) 
        {
            _authService = authService;
            _flyoutMenuBuilder = flyoutMenuBuilder;
            Title = "Loading Page";
        }

        [RelayCommand]
        private async Task CheckUserCredentials()
        {
            if (await _authService.IsJwtValid())
            {
                await _flyoutMenuBuilder.BuildMenu();
                await Shell.Current.GoToAsync(nameof(MainPage), true);
            }
            else
            {
                await ShowMessage("ERROR", "Authentication failed. Login is needed");
                await Shell.Current.GoToAsync(nameof(LoginPage), true);
            }
        }

        private async Task ShowMessage(string title, string message) => await Shell.Current.DisplayAlert(title, message, "OK");
    }
}
