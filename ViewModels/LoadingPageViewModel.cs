
using CarListApp.Services.Core;
using CarListApp.Views;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels
{
    public partial class LoadingPageViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        public LoadingPageViewModel(AuthService authService)
        {
            _authService = authService;
            Title = "Loading Page";
        }

        [RelayCommand]
        private async Task CheckUserCredentials()
        {
            if (await _authService.IsJwtValid())
            {
                await Shell.Current.GoToAsync(nameof(CarListPage), true);
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
