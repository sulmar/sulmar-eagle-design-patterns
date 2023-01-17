using FastDeepCloner;
using System;

namespace PrototypePattern
{
    public record AddCustomerRequest(string name, string street, string city)
    {

    }

    public record AddOrderRequest
    {
        public int Id { get; set; }
    }

    public record Order(string number, decimal amount);

    public class OrderService
    {
        public Order CreateOrder(Order order, string orderNumber)
        {
            return order with { number = orderNumber };
        }
    }

    public class InvoiceService
    {
        public Invoice CreateCopy(Invoice invoice, string newNumber)
        {
            Invoice invoiceCopy = (Invoice) invoice.Clone();
            invoiceCopy.Number = newNumber;

            return invoiceCopy;
        }
    }


}
