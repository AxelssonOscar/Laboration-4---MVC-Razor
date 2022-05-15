using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public class BorrowedBook
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public DateTime ReturnTime { get; set; }

        public bool BeenReturned { get; set; }

    }
}
