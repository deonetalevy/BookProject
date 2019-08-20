using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Models
{
    public class Book
    {
        //Key Field for Book table
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Book Name is required")]
        [StringLength(100, ErrorMessage = "Book Name is required")]
		[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Letters and Numbers Only.")]
		public string BookName { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [StringLength(100, ErrorMessage = "Author Name is required")]
		[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Letters and Numbers Only.")]
		public string AuthorName { get; set; }

        [Required(ErrorMessage = "Price must be entered")]
		[Range(.01, 10000, ErrorMessage ="Price must be positive. Max price is $10000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Publisher must be entered")]
        [DataType(DataType.Text)]
		public string Publisher { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime Date { get; set; }

    }


}
