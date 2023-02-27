using AIRecommendationEngine.Loader.Entities;
using AIRecommendationEngine.Loader.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Loader
{
    public class CSVLoader : IDataLoader
    {
        public BookDetails Load()
        {
            List<Book> books = new List<Book>();
            List<User> users = new List<User>();
            List<BookUserRating> ratings = new List<BookUserRating>();
            Task task = new Task(() =>
            {
                using (StreamReader streamReader = new StreamReader("BX-Books.csv"))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                        books.Add(BookMapper.GetBook(streamReader.ReadLine()));
                }
            });
            Task task1 = new Task(() =>
            {
                using (StreamReader streamReader = new StreamReader("BX-Users.csv"))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                        users.Add(UserMapper.MapUser(streamReader.ReadLine()));
                }
            });
            Task task2 = new Task(() =>
            {
                using (StreamReader streamReader = new StreamReader("BX-Book-Ratings.csv"))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                        ratings.Add(BookRatingMapper.GetBookUserRating(streamReader.ReadLine()));
                }
            });
            task.Start();
            task1.Start();
            task2.Start();
            Task.WaitAll(task,task1,task2);
            BookDetails bookDetails = new BookDetails();

            foreach(var book in books)
            {
                book.bookUserRatings=ratings.FindAll(l => l.ISBN== book.ISBN);
            }
            foreach (var user in users)
            {
                user.userRatings = ratings.FindAll(l => l.UserId==user.UserId);
            }
            foreach (var rate in ratings)
            {
                rate.user = users.Find(u => u.UserId == rate.UserId);
                rate.book = books.Find(b => b.ISBN == rate.ISBN);
            }
            bookDetails.Users=users;
            bookDetails.Books=books;
            bookDetails.BookUsersRatings=ratings;
            return bookDetails;
        }
    }
}
