using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWebApp.Models;
using BookWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        //Constructor to intialize IBookRepository Interface. Automatically returns Book Repository using dependency injection
        //because of transient service in startup class.
        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository; //Local repository is equal to repository passed into the constructor
        }

        //GET: Books/Index
        public IActionResult Index()
        {

            //Use LINQ to get Books
            var books = from b in _bookRepository.GetAllBooks()
                        select b;

            //Contruct view model and set book values and publisher dropdown values
            var publishers = _bookRepository.GetAllPublishers();

            HomeViewModel HomeViewmodel = new HomeViewModel
            {
                Books = books.ToList(),
                Publishers = _bookRepository.SelectList(publishers)
            };

            return View(HomeViewmodel);
        }

        //POST: Books/Index
        //Action Method to be invoked when a post is received
        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {
            //Only add record if data is valid
            if (ModelState.IsValid)
            {
                //Perform method to add book to database then redirect to Record Added action method
                var result = _bookRepository.AddBook(model.Book);

                if (result == true) {

                    return RedirectToAction("RecordAdded");
                }
                else {
                    return RedirectToAction("AddFail");
                }

            }

            //If record is not added because of validation errors, you stay on the same screen. Must get all books for table again
            //Use LINQ to get Books
            var books = from b in _bookRepository.GetAllBooks()
                        select b;

            //Contruct view model and set book values and publisher dropdown values
            var publishers = _bookRepository.GetAllPublishers();

            HomeViewModel HomeViewmodel = new HomeViewModel
            {
                Books = books.ToList(),
                Publishers = _bookRepository.SelectList(publishers)
            };

            
            return View(HomeViewmodel);
        }

        public IActionResult RecordAdded()
        {
            return View();
        }

        public IActionResult AddFail()
        {
            return View();
        }

        //GET: Book/Edit
        public IActionResult EditBook(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }
            //Get Book with matching Id
            var book = _bookRepository.GetAllBooks().ToList().Where(s => s.Id == id).FirstOrDefault();

            //Redirect to index page if book isn't found
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            //Return book object to view if it is found in table
            var publishers = _bookRepository.GetAllPublishers();

            HomeViewModel _HomeViewModel = new HomeViewModel
            {
                Book = book,
                Publishers = _bookRepository.SelectList(publishers)

            };
 

            return View(_HomeViewModel);


        }
        //POST: Books/Edit
        [HttpPost]
        public IActionResult EditBook(Book book)
        {
            //[Bind(include: "Id,BookName,AuthorName,Price,Publisher,Date")] 
            //Only update record if data is valid
            if (ModelState.IsValid)
            {
                //Perform method to add book to database then redirect to Record Added action method
                var result = _bookRepository.UpdateBook(book);

                if (result == true)
                {

                    return RedirectToAction("RecordUpdated");
                }
                else
                {
                    return RedirectToAction("AddFail");
                }

            }
            return View(book);
        }

        //Display this view when record is updated
        public IActionResult RecordUpdated()
        {
            return View();
        }

        //GET: Book/DeleteBook
        public IActionResult DeleteBook(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }
            //Get Book with matching Id
            var book = _bookRepository.GetAllBooks().ToList().Where(s => s.Id == id).FirstOrDefault();

            //Redirect to index page if book isn't found
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            //Return book object to view if it is found in table
            HomeViewModel _HomeViewModel = new HomeViewModel
            {
                Book = book

            };
            return View(_HomeViewModel);


        }

        //POST: Books/Edit
        [HttpPost]
        public IActionResult DeleteBook(Book book)
        {
            //[Bind(include: "Id,BookName,AuthorName,Price,Publisher,Date")] 
            //Only update record if data is valid
            if (ModelState.IsValid)
            {
                //Perform method to add book to database then redirect to Record Added action method
                var result = _bookRepository.DeleteBook(book);

                if (result == true)
                {

                    return RedirectToAction("RecordDeleted");
                }
                else
                {
                    return RedirectToAction("AddFail");
                }

            }
            return View(book);
        }

        //Display this view when record is deleted
        public IActionResult RecordDeleted()
        {
            return View();
        }

        /*Error View
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}
