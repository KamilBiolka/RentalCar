namespace RentalCar;

public partial class AddCarPage : ContentPage
{
    private readonly CarRentalService _service;

    public AddCarPage(CarRentalService service)
    {
        InitializeComponent();
        _service = service;
    }

    private async void OnAddCarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(BrandEntry.Text) ||
            string.IsNullOrWhiteSpace(ModelEntry.Text) ||
            !int.TryParse(YearEntry.Text, out int year))
        {
            await DisplayAlert("B³¹d", "Proszê uzupe³niæ wszystkie pola poprawnie.", "OK");
            return;
        }

        var car = new Car
        {
            Brand = BrandEntry.Text.Trim(),
            Model = ModelEntry.Text.Trim(),
            Year = year
        };

        await _service.AddCarAsync(car);
        await DisplayAlert("Sukces", "Samochód zosta³ dodany.", "OK");
        await Navigation.PopAsync(); 
    }
}