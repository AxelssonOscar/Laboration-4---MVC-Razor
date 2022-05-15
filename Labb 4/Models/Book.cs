using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Author { get; set; }

        [Required]
        public int BookId { get; set; }
        public float BookRating { get; set; }

        public ICollection<BorrowedBook> Borrows { get; set; }
    }
}
