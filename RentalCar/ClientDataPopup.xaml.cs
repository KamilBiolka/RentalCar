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

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            ClientName = NameEntry.Text;
            ClientSurname = SurnameEntry.Text;
            ClientPesel = PeselEntry.Text;

            Close(new Tuple<string, string, string>(ClientName, ClientSurname, ClientPesel));


            
            this.Close();
        }
    }
}