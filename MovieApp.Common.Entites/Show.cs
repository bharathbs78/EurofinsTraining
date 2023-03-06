using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Common.Entites
{
    public class Show
    {
        public int ShowId { get; set; }
        public DateTime ShowTime { get; set; }  
        public double Cost { get; set; }    
        public List<Booking> Bookings { get; set; } =new List<Booking>();   
        public Movie Movie { get; set; }    
        public Screen Screen { get; set; }  
    }
}
