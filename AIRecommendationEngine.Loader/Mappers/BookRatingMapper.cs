using AIRecommendationEngine.Loader.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Loader.Mappers
{
    public class BookRatingMapper
    {
        public static BookUserRating GetBookUserRating(string str)
        {
            string[] strs=str.Replace("\"","").Split(';');
            int UserId= int.Parse(strs[0]);
            string ISBN= strs[1];
            int BookRating= int.Parse(strs[2]);
            BookUserRating bookRating = new BookUserRating
            {
                UserId = UserId,
                ISBN = ISBN,
                Rating = BookRating
            };
            return bookRating;
        }
    }
}
