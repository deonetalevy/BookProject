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

        //This property holds a publisher
        public string Publisher { get; set; }

        //This propery holds all available publishers
        public IEnumerable<SelectListItem> Publishers { get; set; }
    }
}
