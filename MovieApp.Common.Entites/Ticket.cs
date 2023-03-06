using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Common.Entites
{
    public class Ticket
    {
        public long ticketId { get; set; }  
        public Booking Booking { get; set; }    
        public List<Seat> Seats { get; set; }=new List<Seat>(); 
    }
}
