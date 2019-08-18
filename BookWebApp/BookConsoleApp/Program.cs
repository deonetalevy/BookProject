using BookWebApp.Models;
using System;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using System.Data;
using System.Linq;

namespace BookConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Get File Path from user input
            Boolean validPath = false;

            while (validPath == false)
            {
                Console.WriteLine("Enter a Valid File Path");
                var dirPath = @"" + Console.ReadLine();
                //Check if Directory exists. If it does, set the path
                if (Directory.Exists(dirPath))
                {
                    var path = new DirectoryInfo(dirPath);
                    // var files = path.GetFiles();

                    validPath = true;
                }

            }

            using (var db = new BookProjectContext())
            {

                Console.WriteLine("Books will be separated into individual text files " +
                    "based on the Publisher.");
                Console.WriteLine("All books in database:");
                foreach (var book in db.Books)
                {
                    Console.WriteLine(" - {0} | {1} | {2} | {3} | {4} |", book.BookName,
                        book.AuthorName, book.Price, book.Publisher, book.Date);
                }

                Console.WriteLine("Finding Unique Columns");

                var publishers = db.Books.Where(j => j.Id == j.Id)
                    .Select(c => c.Publisher).Distinct().ToList();



            }



            Console.WriteLine("{0} files successfully created.");
        }
    }
}
