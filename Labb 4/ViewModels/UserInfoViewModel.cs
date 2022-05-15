using Labb_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.ViewModels
{
    public class UserInfoViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<BorrowedBook> BorrowedBooks { get; set; }

        public IEnumerable<Book> Books { get; set; }
        public BorrowedBook BorrowedBook { get; set; }
        public Book Book { get; set; }

    }
}
