using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers { get; }

        Customer GetCustomerById(int customerId);

        IEnumerable<BorrowedBook> GetAllBorrowedBooksForCustomer(int customerId);

        void DeleteCustomer(Customer customer);

        void CreateCustomer(Customer customer);
        void EditCustomer(Customer customer);

        void ReturnBook(BorrowedBook book);

        void BorrowBook(Customer customer, Book book);

    }
}
