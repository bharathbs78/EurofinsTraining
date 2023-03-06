using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Common.Entites
{
    public class Seat
    {
        public char RowId { get; set; }
        public int SeatId { get; set; }
        public Ticket Ticket { get; set; }  
    }
}
