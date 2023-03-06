using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Common.Entites
{
    public class Screen
    {
        public int ScreenId { get; set; }   
        public string ScreenName { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public List<Show> Shows { get; set; }=new List<Show>(); 
        public Theatre Theatre { get; set; }    
    }
}
