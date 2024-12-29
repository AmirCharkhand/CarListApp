
using CarListApp.Models;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace CarListApp.ViewModels
{
    public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private Car? _car;

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            try
            {
                Car = query[nameof(Car)] as Car;
                SetTitle();
            }
            catch (Exception ex)
            {
                await ShowErrorRedirectToMain(ex.Message);
            }
        }

        private void SetTitle() => Title = $"Car Details - {Car!.Make} {Car.Model}";

        private async Task ShowErrorRedirectToMain(string error)
        {
            Debug.WriteLine($"Null or Invalid Car: {error}");
            await Shell.Current.DisplayAlert("Error", "Invalid Car", "OK");
            await Shell.Current.GoToAsync(nameof(MainPage), true);
        }
    }
}