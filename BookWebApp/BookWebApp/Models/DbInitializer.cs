using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookWebApp.Models
{
    //Used to initialize the database with some values
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Books.Any()) //If db table is empty, initialize values
            {
                try
                {
                    /*
   context.AddRange
       (
              new Book { BookName = "Charlotte's Web", Price = 2.99, AuthorName = "E.B. White", Date = DateTime.Now, Publisher = "Harper Collins" },
              new Book { BookName = "Matilda", Price = 4.99, AuthorName = "Roald Dahl", Date = DateTime.Now, Publisher = "Penguin Random House" },
              new Book { BookName = "Char", Price = 2.99, AuthorName = "E.B. White", Date = DateTime.Now, Publisher = "Harper Coll" },
              new Book { BookName = "Charl", Price = 2.99, AuthorName = "E.B. White", Date = DateTime.Now, Publisher = "Harper" },
              new Book { BookName = "Charlo", Price = 2.99, AuthorName = "E.B. White", Date = DateTime.Now, Publisher = "HarperCollins" }
       );
   */
                    context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    return;
                }

            }
        }
    }
}
