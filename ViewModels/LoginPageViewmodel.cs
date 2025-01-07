
using CarListApp.Models;
using CarListApp.Services.Core;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels
{
    public partial class LoginPageViewmodel : BaseViewModel
    {
        private readonly AuthService _authService;

        [ObservableProperty] string _userName = string.Empty;
        [ObservableProperty] string _password = string.Empty;

        public LoginPageViewmodel(AuthService authService)
        {
            _authService = authService;
            Title = "Login";
        }

        [RelayCommand]
        private async Task Login()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                await ShowMassage("Error", "Invalid Username or Password");

            try
            {
                IsBuisy = true;
                var loginModel = new LoginModel(UserName, Password);
                await _authService.Login(loginModel);
                await ShowMassage("Welcome", "Successful login");

                await Shell.Current.GoToAsync(nameof(CarListPage), true);
            }
            catch (Exception e)
            {
                await ShowMassage("Error", $"Login failed {e.Message}");
            }
            finally
            {
                IsBuisy = false;
            }
        }

        private async Task ShowMassage(string title, string message) => await Shell.Current.DisplayAlert(title, message, "OK");
    }
}
