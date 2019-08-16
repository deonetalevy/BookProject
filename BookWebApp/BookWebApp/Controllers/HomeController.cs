﻿using System;
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

        //Constructor to intialize IBookRepository Interface. Automatically returns MockBook Repository using dependency injection
        //because of transient service in startup class.
        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository; //Local repository is equal to repository passed into the constructor
        }
        public IActionResult Index()
        {
            
            var books = _bookRepository.GetAllBooks().OrderBy(b => b.BookName);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to the Book Web App",
                Books = books.ToList()
            };

            return View(homeViewModel);
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
