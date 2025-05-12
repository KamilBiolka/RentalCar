using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace RentalCar
{
    public class CarRentalService
    {
        private readonly string filePath = @"C:\Users\kamil\nprojekt\RentalCar\RentalCar\cars.json";
        public List<Car> Cars { get; private set; } = new();

        public async Task LoadCarsAsync()
        {
            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);
                Cars = JsonSerializer.Deserialize<List<Car>>(json) ?? new();
            }
        }

        public async Task SaveCarsAsync()
        {

            string json = JsonSerializer.Serialize(Cars);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task AddCarAsync(Car car)
        {
            Cars.Add(car);
            await SaveCarsAsync();
        }

        public async Task RentCarAsync(string id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car != null && !car.IsRented)
            {
                car.IsRented = true;
                await SaveCarsAsync();
            }
        }

        public async Task ReturnCarAsync(string id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car != null && car.IsRented)
            {
                car.IsRented = false;
                await SaveCarsAsync();
            }
        }
    }
}
