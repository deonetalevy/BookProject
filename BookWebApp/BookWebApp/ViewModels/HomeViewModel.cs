using BookWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWebApp.ViewModels
{
    public class HomeViewModel
    {
        public List<Book> Books { get; set; }
        public Book Book { get; set; }

        public string BookPublisher { get; set; }

    }
}
