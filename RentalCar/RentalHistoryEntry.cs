using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar
{
    public class RentalHistoryEntry
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPesel { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
