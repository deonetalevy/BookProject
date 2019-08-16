using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Models
{
    public class MockBookRepository : IBookRepository
    {
        private List<Book> books;

        //constructor. Will initialize books if empty
        public MockBookRepository()
        {
            if (books == null)
            {
                InitializeBooks();
            }
        }

        private void InitializeBooks()
        {
            books = new List<Book>
            {
                new Book { Id = 1, BookName = "Charlotte's Web", Price = 2.99, AuthorName = "E.B. White", Date = DateTime.Now, Publisher = "Harper Collins"}
                new Book { Id = 2, BookName = "Matilda", Price = 4.99, AuthorName = "Roald Dahl", Date = DateTime.Now, Publisher = "Penguin Random House"}
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
