using CarListApp.Exceptions;
using CarListApp.Models;
using CarListApp.Services.Contracts;
using CarListApp.Services.Core;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CarListApp.ViewModels
{
    public partial class CarListViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private bool _isRefreshing = false;
        [ObservableProperty]
        private string _make;
        [ObservableProperty]
        private string _model;
        [ObservableProperty]
        private string _vin;

        private ICarService CarService
        {
            get 
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                    return _serviceProvider.GetRequiredService<ApiCarService>();
                else
                    return _serviceProvider.GetRequiredService<SqliteCarService>();
            }
        }
        public ObservableCollection<Car> Cars { get; private set; }

        public CarListViewModel(IServiceProvider serviceProvider)
        {
            Title = "Cars List";
            Cars = new ();
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        private async Task GetCars()
        {
            if (IsBuisy) return;
            try
            {
                IsBuisy = true;
                await FillCarsList();
            }
            catch (Exception ex)
            {
                await HandleExeptionWithError(ex, "Unable to get the cars");
            }
            finally 
            {
                IsBuisy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task AddCar()
        {
            if (IsBuisy) return;
            if (!AreUserEntriesValid())
            {
                await DisplayAlert("Error", "Fill all entry fields to insert new car");
                return;
            }
            try
            {
                IsBuisy = true;
                var newCar = new Car() { Make = Make, Model = Model, Vin = Vin };
                await CarService.AddNewCar(newCar);
                await ReloadDataWithShowAlert("Add a new Car", $"{newCar.Make} {newCar.Model} successfuly added");
            }
            catch (Exception ex)
            {
                await HandleExeptionWithError(ex, "Couldn't add the car!");
            }
            finally 
            {
                IsBuisy = false;
            }
        }


        [RelayCommand]
        private async Task DeleteCar(int id)
        {
            if (IsBuisy) return;
            try
            {
                IsBuisy = true;
                await CarService.DeleteCar(id);
                await ReloadDataWithShowAlert("Delete Car", "Car successfully deleted");
            }
            catch (Exception ex)
            {
                await HandleExeptionWithError(ex, "Unable to delete the selected car");
            }
            finally
            {
                IsBuisy = false;
            }
        }

        [RelayCommand]
        async Task GoToCarDetailsPage(Car car)
        {
            if (car == null) return;
            await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>()
            {
                { nameof(Car),car}
            });
        }

        private bool AreUserEntriesValid() => !(string.IsNullOrWhiteSpace(Make) || string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Vin));

        private async Task ReloadDataWithShowAlert(string alertTitle, string alertMessage)
        {
            await DisplayAlert(alertTitle, alertMessage);
            await FillCarsList();
        }

        private async Task FillCarsList()
        {
            if (Cars.Any()) Cars.Clear();
            var cars = await CarService.GetCars();
            foreach (var car in cars) Cars.Add(car);
        }

        private async Task HandleExeptionWithError(Exception ex, string errorMessage)
        {
            Debug.WriteLine($"{errorMessage} - {ex.Message}");
            await DisplayAlert("Error!", errorMessage);

            if (ex is JwtInvalidOrExpierdException)
            {
                await DisplayAlert("Invalid Login", "Your session is not Invalid anymore, Please login to your account.");
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }

        private async Task DisplayAlert(string title, string message)
        {
            await Shell.Current.DisplayAlert(title, message, "OK");
        }
    }
}
