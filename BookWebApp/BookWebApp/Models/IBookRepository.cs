using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Models
{
    public interface IBookRepository
    {
        //Method to get all books
        IEnumerable<Book> GetAllBooks();
        //Method to get all publishers
        IEnumerable<string> GetAllPublishers();

        //Method to create list of publishers for dropdowns
        IEnumerable<SelectListItem> SelectList(IEnumerable<string> elements);

        //Method to add book to database
        Boolean AddBook(Book book);

        //Method to update book record in database
        Boolean UpdateBook(Book book);

        //Method to delete book record from database
        Boolean DeleteBook(Book book);

    }
}
