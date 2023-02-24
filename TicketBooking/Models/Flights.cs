using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Models
{
    public class Flights
    {
        public int ID { get; set; }

        public string StartStation { get; set; }

        public string EndStation { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime DateOfStay { get; set; }

        public Plane Plane { get; set; }

        public float Price { get; set; }
    }
}
