using AIRecommendationEngine.Loader.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Loader.Mappers
{
    public class UserMapper
    {
        public static User MapUser(string str)
        {
            List<string> list= str.Replace("\"","").Split(';').ToList();
            int UserID = int.Parse(list[0]);
            string[] location = list[1].Split(',');
            string City = location[0];
            string Region = location[1];
            string Country= location[2];
            int age = list[2] == "NULL" ? 0 : int.Parse(list[2]);
            User user = new User
            {
                UserId = UserID,
                Age = age,
                City = City,
                State = Region,
                Country = Country,
            };
            return user;
        }
    }
}
