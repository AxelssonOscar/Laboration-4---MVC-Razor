using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appContext;
        
        public CustomerRepository(AppDbContext appDbContext) { _appContext = appDbContext; }

        public IEnumerable<Customer> GetAllCustomers
        {
            get
            {
                return _appContext.Customers.Include(c => c);
            }
        }

        public void CreateCustomer(Customer customer)
        {
            Debug.WriteLine("Customer created:" + customer.FirstName);
            _appContext.Customers.Add(customer);
            _appContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            var currentCostumer = _appContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            Debug.WriteLine(customer.Id);

            if (currentCostumer != null)
            {
                _appContext.Customers.Remove(currentCostumer);
                _appContext.SaveChanges();
            }

        }

        public void EditCustomer(Customer customer)
        {
            var currentcostumer = _appContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (customer != null)
            {
                currentcostumer.FirstName = customer.FirstName;
                currentcostumer.LastName = customer.LastName;
                _appContext.SaveChanges();
            }
        }

        public IEnumerable<BorrowedBook> GetAllBorrowedBooksForCustomer(int customerId)
        {
            var books = _appContext.BorrowedBooks.Where(b => b.CustomerId == customerId).Include(b => b).ThenInclude(b => b.Book);

            foreach(var book in books)
            {
                Debug.WriteLine(book.Book.Title);
            }

            return books;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _appContext.Customers.FirstOrDefault(c => c.Id == customerId);
        }

        public void ReturnBook(BorrowedBook borrowedBook)
        {
            var book = _appContext.BorrowedBooks.FirstOrDefault(bb => bb.Id == borrowedBook.Id);
            if(book != null)
            {
                book.BeenReturned = true;
                _appContext.SaveChanges();
            }
        }

        public void BorrowBook(Customer customer, Book book)
        {
            var borrowedBook = _appContext.Books.FirstOrDefault(b => b.Id == book.Id);
            var borrowedCustomer = _appContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            BorrowedBook newBook = new BorrowedBook();
            newBook.BeenReturned = false;
            newBook.BookId = borrowedBook.BookId;
            newBook.Customer = borrowedCustomer;
            newBook.Book = borrowedBook;
            newBook.CustomerId = borrowedCustomer.Id;
            newBook.ReturnTime = DateTime.Now.AddMonths(1);


            Debug.WriteLine("Customer ID: " + borrowedCustomer.Id);
            Debug.WriteLine("Book ID: " + borrowedBook.Id);

            _appContext.BorrowedBooks.Add(newBook);
            _appContext.SaveChanges();



        }

    }
}
