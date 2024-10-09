using CarListApp.Models;
using CarListApp.Services.Contracts;
using SQLite;

namespace CarListApp.Services.Core
{
    public class SqliteCarService : ICarService
    {
        private readonly SQLiteConnection _connection;

        public string StatusMessage { get; private set; } = string.Empty;

        public SqliteCarService(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Car>();
        }

        public async Task<List<Car>> GetCars()
        {
            try
            {
                var cars = _connection!.Table<Car>().ToList();
                await Task.CompletedTask;
                return cars;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Couldn't retrieve Cars {ex.Message}";
            }
            return new List<Car>();
        }

        public async Task AddNewCar(Car newCar)
        {
            try
            {
                var result = _connection!.Insert(newCar);
                await Task.CompletedTask;
                StatusMessage = result == 0 ? "Insert Failed." : "Car Inserted";
                return;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Couldn't add the new Car {ex.Message}";
            }
        }

        public async Task DeleteCar(int id)
        {
            try
            {
                var result = _connection!.Delete<Car>(id);
                StatusMessage = result == 0 ? "Delete Failed." : "Car Deleted";
                await Task.CompletedTask;
                return;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Couldn't delete the Car {ex.Message}";
            }
        }

        public Task<Car> GetCarById(int carId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
