using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWebApp.Models;
using BookWebApp.ViewModels;

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
        public IActionResult Index()
        {          
            return View();
        }

        //Action Method to be invoked when a post is received
        [HttpPost]
        public IActionResult Index(Book book)
        {
            //Only add record if data is valid
            if (ModelState.IsValid)
            {
                //Set Date Time Field for record
                book.Date = DateTime.Now;
                //Perform method to add book to database then redirect to Record Added action method
                _bookRepository.AddBook(book);
                return RedirectToAction("RecordAdded");
            }
            return View(book);
        }

        public IActionResult RecordAdded()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
