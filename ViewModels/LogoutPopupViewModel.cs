using CarListApp.Services.Core;
using CarListApp.Views;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels
{
    public partial class LogoutPopupViewModel(AuthService authService) : BaseViewModel
    {
        private readonly AuthService _authService = authService;

        [RelayCommand]
        private async Task Logout()
        {
            _authService.Logout();
            await Shell.Current.GoToAsync(nameof(LoginPage), true);
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
