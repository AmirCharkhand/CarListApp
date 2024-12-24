
using CarListApp.Models;
using CarListApp.Services.Contracts;
using System.Net.Http.Json;

namespace CarListApp.Services.Core
{
    public class ApiCarService : ICarService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UriBuilderService _uriBuilderService;

        private HttpClient HttpClient => _httpClientFactory.CreateClient("Authorized");

        public ApiCarService(IHttpClientFactory httpClientFactory, UriBuilderService uriBuilderService)
        {
            _httpClientFactory = httpClientFactory;
            _uriBuilderService = uriBuilderService;
        }

        public async Task AddNewCar(Car car)
        {
            var response = await HttpClient.PostAsJsonAsync<Car>(_uriBuilderService.GetAddCarUri(), car);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCar(int carId)
        {
            var response = await HttpClient.DeleteAsync(_uriBuilderService.GetDeleteCarUri(carId));
            response.EnsureSuccessStatusCode();
        }

        public async Task<Car> GetCarById(int carId)
        {
            var response = await HttpClient.GetAsync(_uriBuilderService.GetGetCarUri(carId));
            response.EnsureSuccessStatusCode();
            var car = await response.Content.ReadFromJsonAsync<Car>();
            return car ?? throw new NullReferenceException();
        }

        public async Task<List<Car>> GetCars()
        {
            var response = await HttpClient.GetAsync(_uriBuilderService.GetGetCarsUri());
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
