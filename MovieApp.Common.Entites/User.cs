using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Common.Entites
{
    public class User
    {
        public long UserId { get; set; }    
        public string LongName { get; set; }    
        public string FirstName { get; set; }   
        public string LastName { get; set; } 
        public Address UserAddress { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();   
    }
}
