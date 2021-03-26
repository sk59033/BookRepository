using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BookRepository.Models
{
    public class Books
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Status is required")]

        [Range(1, 2,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Status { get; set; }
    }
}
