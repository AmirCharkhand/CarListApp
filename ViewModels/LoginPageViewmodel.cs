
using CarListApp.Models;
using CarListApp.Services.Core;
using CarListApp.Services.Helpers;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels
{
    public partial class LoginPageViewmodel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly FlyoutMenuBuilderService _flyoutMenuBuilder;

        [ObservableProperty] string _userName = string.Empty;
        [ObservableProperty] string _password = string.Empty;

        public LoginPageViewmodel(AuthService authService, FlyoutMenuBuilderService flyoutMenuBuilder)
        {
            _authService = authService;
            _flyoutMenuBuilder = flyoutMenuBuilder;
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
                await _flyoutMenuBuilder.BuildMenu();
                await Shell.Current.GoToAsync(nameof(MainPage));
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
