using RentalCar;
using System.Collections.ObjectModel;
using RentalCar.ViewModels;
using CommunityToolkit.Maui.Views;


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

    private CarRentalService carRentalService = new();
    private async void RentCar_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var car = (Car)button.BindingContext;

        var popup = new ClientDataPopup();
        var result = await MainPageRef.ShowPopupAsync(popup) as Tuple<string, string, string>;

        if (result != null)
        {
            car.IsRented = true;
            car.RentedByName = result.Item1;
            car.RentedBySurname = result.Item2;
            car.RentedByPESEL = result.Item3;

            await carRentalService.SaveCarsAsync();
        }
    }
}