using Labb_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        


    }
}
