
using CarListApp.Models;

namespace CarListApp.Services.Contracts
{
    public interface ICarService
    {
        public Task<List<Car>> GetCars();
        public Task<Car> GetCarById(int carId);
        public Task AddNewCar(Car car);
        public Task DeleteCar(int carId);
        public Task UpdateCar(Car car);
    }
}
