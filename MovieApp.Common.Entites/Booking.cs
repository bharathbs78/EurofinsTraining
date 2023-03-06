using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Common.Entites
{
    public class Booking
    {
        public long BookingId { get; set; } 
        public DateTime BookingDate { get; set; }   
        public User User { get; set; }  
        public Show Show { get; set; }  
        public List<Ticket> Tickets { get; set; }
    }
}
