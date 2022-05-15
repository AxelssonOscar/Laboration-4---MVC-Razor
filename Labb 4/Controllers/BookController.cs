using Labb_4.Models;
using Labb_4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository) { _bookRepository = bookRepository; }


        public IActionResult List()
        {
            BooksViewModel bookViewModel = new BooksViewModel();
            bookViewModel.Books = _bookRepository.GetAllBooks;
            return View(bookViewModel);
        }
    }
}
