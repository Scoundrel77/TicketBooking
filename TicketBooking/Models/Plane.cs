using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Models
{
    public class Plane
    {
        public int ID { get; set; }

        public string NamePlane { get; set; }

        public int NumberOfVacancies { get; set; }

        public bool IsFree { get; set; }
    }
}
