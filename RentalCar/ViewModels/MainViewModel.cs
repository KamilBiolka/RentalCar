using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using RentalCar;

namespace RentalCar.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; set; } = new();
        public ICommand ToggleRentalCommand { get; }

        private readonly CarRentalService _carRentalService;

        public MainViewModel()
        {
            _carRentalService = new CarRentalService();
            ToggleRentalCommand = new Command<Car>(async (car) => await ToggleRentalAsync(car));

            
            LoadCarsAsync();
        }

        private async void LoadCarsAsync()
        {
            await _carRentalService.LoadCarsAsync();
            Cars.Clear();
            foreach (var car in _carRentalService.Cars)
            {
                Cars.Add(car);
            }
        }

        private async Task ToggleRentalAsync(Car car)
        {
            if (car == null)
                return;

            if (car.IsRented)
                await _carRentalService.ReturnCarAsync(car.Id);
            else
                await _carRentalService.RentCarAsync(car.Id);

            
            LoadCarsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}