
using CarListApp.Models;
using CarListApp.Services.Contracts;

namespace CarListApp.Services.Core
{
    public class ApiCarService : ICarService
    {
        private readonly HttpClient _httpClient;

        public string StatusMessage { get; private set; } = string.Empty;

        public ApiCarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddNewCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCar(int carId)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCarById(int carId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> GetCars()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
