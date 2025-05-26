using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar
{
    public class Car : INotifyPropertyChanged
    {
        public List<RentalHistoryEntry> RentalHistory { get; set; } = new List<RentalHistoryEntry>();
        public string Id { get; set; } = Guid.NewGuid().ToString();

        private string brand;
        public string Brand
        {
            get => brand;
            set
            {
                if (brand != value)
                {
                    brand = value;
                    OnPropertyChanged(nameof(Brand));
                }
            }
        }

        private string model;
        public string Model
        {
            get => model;
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        private int year;
        public int Year
        {
            get => year;
            set
            {
                if (year != value)
                {
                    year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

        private bool isRented;
        public bool IsRented
        {
            get => isRented;
            set
            {
                if (isRented != value)
                {
                    isRented = value;
                    OnPropertyChanged(nameof(IsRented));
                }
            }
        }

        private string rentedByName;
        public string RentedByName
        {
            get => rentedByName;
            set
            {
                if (rentedByName != value)
                {
                    rentedByName = value;
                    OnPropertyChanged(nameof(RentedByName));
                }
            }
        }

        private string rentedBySurname;
        public string RentedBySurname
        {
            get => rentedBySurname;
            set
            {
                if (rentedBySurname != value)
                {
                    rentedBySurname = value;
                    OnPropertyChanged(nameof(RentedBySurname));
                }
            }
        }

        private string rentedByPESEL;
        public string RentedByPESEL
        {
            get => rentedByPESEL;
            set
            {
                if (rentedByPESEL != value)
                {
                    rentedByPESEL = value;
                    OnPropertyChanged(nameof(RentedByPESEL));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
