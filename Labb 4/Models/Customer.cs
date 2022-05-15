using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<BorrowedBook> BorrowedBooks { get; set; }



    }
}
