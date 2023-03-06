using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Common.Entites
{
    public class Theatre
    {
        public int TheatreId { get; set; }  
        public string TheatreName { get;set; }  
        public List<Screen> Screens { get; set; }= new List<Screen>();  
    }
}
