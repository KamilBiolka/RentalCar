using RentalCar;
using System.Collections.ObjectModel;
using RentalCar.ViewModels;

namespace RentalCar;

public partial class MainPage : ContentPage
{
    private CarRentalService _service = new();
    public ObservableCollection<Car> Cars { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _service.LoadCarsAsync();
        Cars.Clear();
        foreach (var car in _service.Cars)
        {
            Cars.Add(car);
        }
    }

    private async void RentCar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Car car)
        {
            await _service.RentCarAsync(car.Id);
            RefreshList();
        }
    }

    private async void ReturnCar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Car car)
        {
            await _service.ReturnCarAsync(car.Id);
            RefreshList();
        }
    }

    private void RefreshList()
    {
        Cars.Clear();
        foreach (var car in _service.Cars)
        {
            Cars.Add(car);
        }
    }

    private async void OnAddCarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCarPage(_service));
    }
}