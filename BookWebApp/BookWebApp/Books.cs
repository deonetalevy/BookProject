using System;
using System.Collections.Generic;

namespace BookWebApp
{
    public partial class Books
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public string Publisher { get; set; }
        public DateTime Date { get; set; }
    }
}
