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
					//Code to seed table with Initial Values if needed
					/*
					   context.AddRange
						   (
								  new Book { BookName = "", Price = , AuthorName = "", Date = DateTime.Now, Publisher = "Penguin Random House" },
								  new Book { BookName = "", Price = , AuthorName = "", Date = DateTime.Now, Publisher = "Hachette Livre" },
								  new Book { BookName = "", Price = , AuthorName = "", Date = DateTime.Now, Publisher = "Springer Nature" },
								  new Book { BookName = "", Price = , AuthorName = "", Date = DateTime.Now, Publisher = "Simon & Schuster" },
								  new Book { BookName = "", Price = , AuthorName = "", Date = DateTime.Now, Publisher = "Harper Collins" }
						   );
   
                    context.SaveChanges(); 
					*/
				}
				catch (Microsoft.EntityFrameworkCore.DbUpdateException)
				{
					return;
				}

			}
		}
	}
}
