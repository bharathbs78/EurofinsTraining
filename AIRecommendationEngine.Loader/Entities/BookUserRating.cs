using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Loader.Entities
{
    public class BookUserRating
    {
        public int Rating { get; set; }
        public string ISBN { get; set; }
        public int UserId { get; set; }
        public Book book { get; set; }
        public User user { get; set; }
    }
}
