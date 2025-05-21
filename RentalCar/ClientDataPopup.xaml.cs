using System.Text.RegularExpressions;
using CommunityToolkit.Maui.Views;

namespace RentalCar
{
    public partial class ClientDataPopup : Popup
    {
        public string ClientName { get; private set; }
        public string ClientSurname { get; private set; }
        public string ClientPesel { get; private set; }

        public ClientDataPopup()
        {
            InitializeComponent();
        }

        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text?.Trim();
            string surname = SurnameEntry.Text?.Trim();
            string pesel = PeselEntry.Text?.Trim();

            
            Regex nameRegex = new Regex(@"^[A-Za-z•π∆Ê Í£≥—Ò”ÛåúèüØø]{2,}$");
            Regex peselRegex = new Regex(@"^\d{11}$");

            
            if (string.IsNullOrWhiteSpace(name) || !nameRegex.IsMatch(name))
            {
                await Application.Current.MainPage.DisplayAlert("B≥πd", "ImiÍ musi zawieraÊ tylko litery (min. 2 znaki).", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(surname) || !nameRegex.IsMatch(surname))
            {
                await Application.Current.MainPage.DisplayAlert("B≥πd", "Nazwisko musi zawieraÊ tylko litery (min. 2 znaki).", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(pesel) || !peselRegex.IsMatch(pesel))
            {
                await Application.Current.MainPage.DisplayAlert("B≥πd", "PESEL musi mieÊ dok≥adnie 11 cyfr.", "OK");
                return;
            }

            
            ClientName = name;
            ClientSurname = surname;
            ClientPesel = pesel;

            Close(new Tuple<string, string, string>(ClientName, ClientSurname, ClientPesel));
        }
    }
}