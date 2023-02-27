using AIRecommendationEngine.Loader.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Loader.Mappers
{
    public class BookMapper
    {
        public static Book GetBook(string str)
        {
            string[] strs = str.Replace("\"","").Split(';');
            string ISBN = strs[0];
            string Title= strs[1];
            string Author= strs[2];
            string Year= strs[3];
            string Publisher= strs[4];
            string Image_S= strs[5];
            string Image_M= strs[6];
            string Image_L= strs[7];
            Book book = new Book
            {
                Title = Title,
                Author = Author,
                Year = Year,
                Publisher = Publisher,
                ISBN = ISBN,
                Image_L_URL = Image_L,
                Image_M_URL = Image_M,
                Image_S_URL = Image_S
            };
            return book;
        } 
    }
}
