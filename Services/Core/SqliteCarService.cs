using CarListApp.Models;
using CarListApp.Services.Contracts;
using SQLite;

namespace CarListApp.Services.Core
{
    public class SqliteCarService : ICarService
    {
        private readonly SQLiteConnection _connection;

        public SqliteCarService(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Car>();
        }

        public async Task<List<Car>> GetCars()
        {
            var cars = _connection!.Table<Car>().ToList();
            await Task.CompletedTask;
            return cars;
        }

        public async Task AddNewCar(Car newCar)
        {
            var result = _connection!.Insert(newCar);
            await Task.CompletedTask;
            if (result == 0)
                throw new Exception("DB error: Couldn't add the new car");
        }

        public async Task DeleteCar(int id)
        {
            var result = _connection!.Delete<Car>(id);
            await Task.CompletedTask;
            if (result == 0)
                throw new Exception("DB error: Couldn't Delete the Car");
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
