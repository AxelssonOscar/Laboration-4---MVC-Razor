using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appContext;

        public BookRepository(AppDbContext appDbContext) { _appContext = appDbContext; }


        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                var books = _appContext.Books.Select(b => b);

                return books;
            }
        }
    }
}
