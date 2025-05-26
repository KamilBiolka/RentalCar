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


    private void ReturnCar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var car = button?.BindingContext as Car;

        if (car != null)
        {
            car.IsRented = false;
            car.RentedByName = null;
            car.RentedBySurname = null;
            car.RentedByPESEL = null;

            
            var lastEntry = car.RentalHistory.LastOrDefault(entry => entry.ReturnDate == null);
            if (lastEntry != null)
            {
                lastEntry.ReturnDate = DateTime.Now;
            }
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
        var result = await this.ShowPopupAsync(popup);

        if (result is Tuple<string, string, string> clientData)
        {
            car.RentedByName = clientData.Item1;
            car.RentedBySurname = clientData.Item2;
            car.RentedByPESEL = clientData.Item3;
            car.IsRented = true;

            
            car.RentalHistory.Add(new RentalHistoryEntry
            {
                ClientName = clientData.Item1,
                ClientSurname = clientData.Item2,
                ClientPesel = clientData.Item3,
                RentDate = DateTime.Now
            });
        }
    }

    private async void ShowHistory_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var car = button?.BindingContext as Car;

        if (car != null)
        {
            var popup = new RentalHistoryPopup(car.RentalHistory);
            await this.ShowPopupAsync(popup);
        }
    }
}