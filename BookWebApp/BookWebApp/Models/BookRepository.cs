using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Models
{
    public class BookRepository : IBookRepository
    {
        //Need to pass in DbContext through a constructor
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Method to Get all Books
        public IEnumerable<Book> GetAllBooks()
        {
            return _appDbContext.Books; //Checks if Book is already populated. If not, it retrieves the data from the Books table in the database
        }

        //Method to Get book by Id
        /*
        public Book GetBookById(int bookId)
        {
            return _appDbContext.Books.FirstOrDefault(b => b.Id == bookId);
        }
        */

        //Method to Add Book to database
        public Boolean AddBook(Book book)
        {
            String _bookName = book.BookName;
            //Check Books table for an existing duplicate Book Name using LINQ query before adding record to table
            bool dupeName = _appDbContext.Books.AsEnumerable()
                .Any(row => row.BookName == _bookName);

            //If duplicate records are found, return false
            if (dupeName == true)
            {
                return false;
            }
            else
            {
                //Add record to table and return true if no duplicate records are found
                book.Date = DateTime.Now;
                _appDbContext.Books.Add(book);
                _appDbContext.SaveChanges();

                return true;    
            }
        }
    }
}
