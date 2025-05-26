using CommunityToolkit.Maui.Views;

namespace RentalCar
{
    public partial class RentalHistoryPopup : Popup
    {
        public RentalHistoryPopup(List<RentalHistoryEntry> history)
        {
            InitializeComponent();
            HistoryListView.ItemsSource = history.OrderByDescending(h => h.RentDate).ToList();
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}