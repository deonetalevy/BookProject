﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();


        //Method to add book to database
        Boolean AddBook(Book book);

        //Method to update book record in database
        Boolean UpdateBook(Book book);

        //Method to delete book record from database
        Boolean DeleteBook(Book book);

    }
}
