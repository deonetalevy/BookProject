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
        public Book GetBookById(int bookId)
        {
            return _appDbContext.Books.FirstOrDefault(b => b.Id == bookId);
        }
    }
}
