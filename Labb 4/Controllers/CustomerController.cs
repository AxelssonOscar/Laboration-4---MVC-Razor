using Labb_4.Models;
using Labb_4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository) { _customerRepository = customerRepository; _bookRepository = bookRepository; }

        public IActionResult List()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerRepository.GetAllCustomers;
            return View(customerViewModel);
        }


        public IActionResult UserInfo(int id)
        {
            UserInfoViewModel userInfoViewModel = new UserInfoViewModel();
            userInfoViewModel.Customer = _customerRepository.GetCustomerById(id);
            userInfoViewModel.BorrowedBooks = _customerRepository.GetAllBorrowedBooksForCustomer(id);
            userInfoViewModel.Books = _bookRepository.GetAllBooks; 

            return View(userInfoViewModel);
        }

        public IActionResult Create(Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
            return RedirectToAction("List");
        }

        public IActionResult Edit(Customer customer)
        {
            _customerRepository.EditCustomer(customer);
            return RedirectToAction("UserInfo", new { id = customer.Id });
        }

        public IActionResult Delete(Customer customer)
        {
            _customerRepository.DeleteCustomer(customer);
            return RedirectToAction("List");
        }

        public IActionResult ReturnBook(Customer customer, BorrowedBook borrowedBook)
        {
            Debug.WriteLine(borrowedBook.Id);
            _customerRepository.ReturnBook(borrowedBook);
            return RedirectToAction("UserInfo", new { id = customer.Id });
        }

        public IActionResult BorrowBook(Customer customer, Book book)
        {
            //Debug.WriteLine("Customer ID: " + customer.Id);
            //Debug.WriteLine("Book ID: " + book.Id);

            _customerRepository.BorrowBook(customer, book);

            return RedirectToAction("UserInfo", new { id = customer.Id });
        }




    }
}
