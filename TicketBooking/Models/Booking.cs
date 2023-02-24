using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Models
{
    class Booking
    {
        public int Id { get; set; }

        public Users User { get; set; }

        public Flights Flight { get; set; }
    }
}
