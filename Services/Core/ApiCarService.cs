
using CarListApp.Models;
using CarListApp.Services.Contracts;
using System.Diagnostics;
using System.Net.Http.Json;

namespace CarListApp.Services.Core
{
    public class ApiCarService : ICarService
    {
        private readonly HttpClient _httpClient;
        private readonly UriBuilderService _uriBuilderService;

        public ApiCarService(HttpClient httpClient, UriBuilderService uriBuilderService)
        {
            _httpClient = httpClient;
            _uriBuilderService = uriBuilderService;
        }

        public async Task AddNewCar(Car car)
        {
            var response = await _httpClient.PostAsJsonAsync<Car>(_uriBuilderService.GetAddCarUri(), car);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCar(int carId)
        {
            var response = await _httpClient.DeleteAsync(_uriBuilderService.GetDeleteCarUri(carId));
            response.EnsureSuccessStatusCode();
        }

        public async Task<Car> GetCarById(int carId)
        {
            var response = await _httpClient.GetAsync(_uriBuilderService.GetGetCarUri(carId));
            response.EnsureSuccessStatusCode();
            var car = await response.Content.ReadFromJsonAsync<Car>();
            return car ?? throw new NullReferenceException();
        }

        public async Task<List<Car>> GetCars()
        {
            var response = await _httpClient.GetAsync(_uriBuilderService.GetGetCarsUri());
            response.EnsureSuccessStatusCode();
            var cars = await response.Content.ReadFromJsonAsync<List<Car>>();
            return cars ?? throw new NullReferenceException();
        }

        public Task UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
