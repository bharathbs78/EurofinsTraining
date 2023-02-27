using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Loader.Entities
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Publisher { get; set; }
        public string Image_S_URL { get; set; }
        public string Image_M_URL { get; set; }
        public string Image_L_URL { get;set; }
        public List<BookUserRating> bookUserRatings { get; set; }=new List<BookUserRating>();   
    }
}
