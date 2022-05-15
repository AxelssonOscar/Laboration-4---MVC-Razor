using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks { get; }
    }
}
