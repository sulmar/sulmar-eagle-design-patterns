using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    // Proxy
    // Wariant klasowy
    public class InvoiceProxy : Invoice
    {
        private static int numberOfCopy;
        public override void Print()
        {
            numberOfCopy++;

            base.Print();
        }

        public override Customer Customer { 
        get 
        {
                Console.WriteLine($"Log ");

                return base.Customer; 
            } 
            
            set => base.Customer = value; }
    }

    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual void Print()
        {
            Console.WriteLine(Number);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        

    }

    public class CustomerProxy
    {
        private readonly Customer customer;
        public CustomerProxy(Customer customer)
        {
            this.customer = customer;
        }
    }

    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(); 
    }

    public class CustomersService : ICustomerService
    {
        private readonly IEnumerable<Customer> customers;

        public IEnumerable<Customer> GetAll()
        {
            return customers;
        }
    }


}
