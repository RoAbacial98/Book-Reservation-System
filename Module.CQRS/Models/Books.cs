using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreReservation.Module.CQRS.Models
{
    public class Books
    {
        public string BookID { get; set; }
        public string BookName { get; set; }
        public bool BookReserve { get; set; }
        public string BookReserveNumber { get; set; }

        public static List<Books> books = new List<Books>{
                new Books {
                    BookID = "9b0896fa-3880-4c2e-bfd6-925c87f22878",
                    BookName = "CQRS for Dummies",
                    BookReserve = false,
                    BookReserveNumber = ""
                },
                new Books {
                    BookID = "0550818d-36ad-4a8d-9c3a-a715bf15de76",
                    BookName = "Visual Studio Tips",
                    BookReserve = false,
                    BookReserveNumber = ""
                },new Books {
                    BookID = "8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1",
                    BookName = "NHibernate Cookbook",
                    BookReserve = false,
                    BookReserveNumber = ""
                }
            };

        public List<Books> AllBooks()
        {
            return books.ToList();
        }


        public List<Books> AddBooks(Books book)
        {
            books.Add(new Books
            {
                BookID = book.BookID,
                BookName = book.BookName,
                BookReserve = book.BookReserve,
                BookReserveNumber = book.BookReserveNumber
            });
            return books;
        }


        public Books RemoveBooks(string bookId)
        {
            var book = books.Where(x => x.BookID == bookId).AsQueryable().SingleOrDefault();
            books.Remove(book);
            return book;
        }

    }
}