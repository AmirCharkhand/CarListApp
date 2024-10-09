using CarListApp.Models;
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
        private readonly SqliteCarService _carService;

        [ObservableProperty]
        private bool _isRefreshing = false;
        [ObservableProperty]
        private string _make;
        [ObservableProperty]
        private string _model;
        [ObservableProperty]
        private string _vin;

        public ObservableCollection<Car> Cars { get; private set; }

        public CarListViewModel(SqliteCarService carService)
        {
            Title = "Cars List";
            Cars = new ();
            _carService = carService;
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
                await _carService.AddNewCar(newCar);
                await ReloadDataWithShowAlert("Insert Car");
            }
            catch (Exception ex)
            {
                await HandleExeptionWithError(ex, "Unable to add the New Car");
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
                await _carService.DeleteCar(id);
                await ReloadDataWithShowAlert("Delete Car");
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

        private async Task ReloadDataWithShowAlert(string alertTitle)
        {
            await DisplayAlert(alertTitle, _carService.StatusMessage);
            await FillCarsList();
        }

        private async Task FillCarsList()
        {
            if (Cars.Any()) Cars.Clear();
            var cars = await _carService.GetCars();
            foreach (var car in cars) Cars.Add(car);
        }

        private async Task HandleExeptionWithError(Exception ex, string errorMessage)
        {
            Debug.WriteLine($"{errorMessage} - {ex.Message}");
            Debug.WriteLine($"Car Service Status: {_carService.StatusMessage}");
            await DisplayAlert("Error!", errorMessage);
        }

        private async Task DisplayAlert(string title, string message)
        {
            await Shell.Current.DisplayAlert(title, message, "OK");
        }
    }
}
