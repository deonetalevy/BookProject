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

            //Directory path variable. Default to "c:\\" to avoid build error
            string dirPath = "c:";

            Boolean validPath = false;
            //Try to write message
            try
            {
                Console.WriteLine("Enter a Valid File Path");
            }
            catch (IOException)
            {
                return;
            }

            //Try to read in file name
            try
            {
                dirPath = @"" + Console.ReadLine();
            }
            catch (IOException)
            {
                return;
            }
            catch (OutOfMemoryException)
            {
                return;
            }

            //Get File Path from user input
            //Execute While statement until valid path is entered
            while (validPath == false)
            {

                //Check if Directory exists. If it does, set the path
                if (Directory.Exists(dirPath))
                {
                    try
                    {
                        var path = new DirectoryInfo(dirPath);
                    }
                    catch (System.Security.SecurityException)
                    {
                        return;
                    }
                    catch (PathTooLongException)
                    {
                        return;
                    }
                    // var files = path.GetFiles();

                    //Exit while statement by meeting condition
                    validPath = true;
                }
                else
                {
                    try
                    {
                        //Prompt user to enter a valid file path
                        Console.WriteLine("{0} is not a valid File Path." +
                            " Enter a Valid File Path", dirPath);
                    }
                    catch (IOException)
                    {
                        return;
                    }

                    //Try do read in directory to dirPath variable
                    try
                    {
                        dirPath = @"" + Console.ReadLine();
                    }
                    catch (IOException)
                    {
                        return;
                    }
                    catch (OutOfMemoryException)
                    {
                        return;
                    }
                }

            }

            //Get Book data from database, then write file
            using (var db = new BookProjectContext())
            {
                //Try to write notification message to screen
                try
                {
                    Console.WriteLine("Books will be separated into individual text files " +
                        "based on the Publisher." + Environment.NewLine +
                        "Finding Unique Publishers in database...");
                }
                catch (IOException)
                {
                    return;
                }


                //Find unique publishers in database and save to list
                var publishers = db.Books.Where(j => j.Id == j.Id)
                    .Select(c => c.Publisher).Distinct().ToList();

                //Write books belonging to each publisher in the list to a text file
                foreach (var pub in publishers)
                {

                    //Set: File name set to Publisher Name
                    var filename = pub + " Books.txt";
                    StreamWriter tw;

                    //Create: TextWriter object for writing to file
#pragma warning disable UnhandledExceptions // Unhandled exception(s)
                    tw = new StreamWriter(Path.Combine(dirPath, filename));
#pragma warning restore UnhandledExceptions // Unhandled exception(s)



                    //Get: A list of all books from database that have the current publisher name
                    var _books = db.Books.Where(j => j.Publisher == pub).ToList();

                    if (tw is null)
                    {
                        //Write each record to the file using loop
                        foreach (var record in _books)
                        {
                            var line = record.BookName + " | " + record.AuthorName + " | " + record.Price;
                            tw.WriteLine(line);
                        }
                    }
                    //Close streamwriter object
                    tw.Close();

                }

                //Try to write message to screen
                try
                {
                    Console.WriteLine("{0} files successfully created.", publishers.Count);
                }
                catch (IOException)
                {
                    return;
                }
            }
        }
    }
}
