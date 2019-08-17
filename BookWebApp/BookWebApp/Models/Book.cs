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

        [Required]
        [StringLength(100, ErrorMessage = "Book Name is required")]
        public string BookName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Author Name is required")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Price must be entered")]
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
