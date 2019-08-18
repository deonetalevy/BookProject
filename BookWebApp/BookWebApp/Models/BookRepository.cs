using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        //Method to Update Book Record in database
        public Boolean UpdateBook(Book book)
        {

            //Update record in table and return true             
            //Turn off Tracking and Use logic to allow record to be updated when the Book Name isn't changing             
            _appDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (book.BookName == _appDbContext.Books.Where(x => x.Id == book.Id).SingleOrDefault().BookName)
            {
                //Update record in table and return true
                if (book != null)
                {

                    //Set date and update record
                    book.Date = DateTime.Now;
                    _appDbContext.Entry(book).State = EntityState.Modified;
                    _appDbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //Check Books table for an existing duplicate Book Name using LINQ query before updating record
                bool dupeName = _appDbContext.Books.AsEnumerable()
                    .Any(row => row.BookName == book.BookName);

                //If duplicate records are found, return false
                if (dupeName == true)
                {
                    return false;
                }
                else
                {
                    if (book != null)
                    {
                        book.Date = DateTime.Now;
                        _appDbContext.Entry(book).State = EntityState.Modified;
                        _appDbContext.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        //Method to delete book record from table
        public Boolean DeleteBook(Book book)
        {

            //Delete record from table
            if (book != null)
            {

                _appDbContext.Remove(book);
                _appDbContext.SaveChanges();

                return true;
            }
            return false;

        }

        //Method to Set list for all genres
        public IEnumerable<string> GetAllPublishers()
        {
            return new List<string>
            {
                "Penguin Random House",
                "Hachette Livre",
                "Springer Nature",
                "Simon & Schuster",
                "Harper Collins",
            };
        }

        public IEnumerable<SelectListItem> SelectList(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // This loop will cause mvc to render each item as <option value="Publisher">Publisher</option>
            //in the dropdown list
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}
