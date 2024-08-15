using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane_Ticket_Booking
{
    public class ComboBoxItem
    {
        public string ShortCode { get; set; }
        public int FlightId { get; set; }

        public ComboBoxItem(string shortCode, int flightId)
        {
            ShortCode = shortCode;
            FlightId = flightId;
        }

        public override string ToString()
        {
            return ShortCode;
        }
    }
}
