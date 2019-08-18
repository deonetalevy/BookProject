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
        static void Main()
        {

            //Directory path variable
            string dirPath;

            Boolean validPath = false;

            Console.WriteLine("Enter a Valid File Path");
            dirPath = @"" + Console.ReadLine();

            //Get File Path from user input
            //Execute While statement until valid path is entered
            while (validPath == false)
            {
                
                //Check if Directory exists. If it does, set the path
                if (Directory.Exists(dirPath))
                {
                    var path = new DirectoryInfo(dirPath);
                    // var files = path.GetFiles();

                    //Exit while statement by meeting condition
                    validPath = true;
                }
                else
                {
                    //Prompt user to enter a valid file path
                    Console.WriteLine("{0} is not a valid File Path", dirPath);
                    Console.WriteLine("Enter a Valid File Path");
                    dirPath = @"" + Console.ReadLine();
                }

            }

            //Get Book data from database, then write file
            using (var db = new BookProjectContext())
            {

                Console.WriteLine("Books will be separated into individual text files " +
                    "based on the Publisher.");
                Console.WriteLine("Finding Unique Publishers in database...");

                //Find unique publishers in database and save to list
                var publishers = db.Books.Where(j => j.Id == j.Id)
                    .Select(c => c.Publisher).Distinct().ToList();

                //Write books belonging to each publisher in the list to a text file
                foreach (var pub in publishers)
                {
                    Console.WriteLine("{0}", pub);
                    //Set: File name set to Publisher Name
                    var filename = pub + " Books.txt";

                    //Create: TextWriter object for writing to file
                    var tw = new StreamWriter(Path.Combine(dirPath, filename));

                    //Get: A list of all books from database that have the current publisher name
                    var _books = db.Books.Where(j => j.Publisher == pub).ToList();

                    //Write each record to the file using loop
                    foreach (var record in _books)
                    {
                        var line = record.BookName + " | " + record.AuthorName + " | " + record.Price;
                        tw.WriteLine(line);
                    }

                    //Close streamwriter object
                    tw.Close();

                }

                Console.WriteLine("{0} files successfully created.", publishers.Count);

            }




        }
    }
}
