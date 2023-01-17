using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PrototypePattern
{

    

    



    public class Invoice : ICloneable
    {
        public Invoice(string number, 
            DateTime createDate, PaymentType paymentType, Customer customer, DateTime dueDate)
        {
            Number = number;
            CreateDate = createDate;
            PaymentType = paymentType;
            Customer = customer;
            DueDate = dueDate;
        }

        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public Customer Customer { get; set; }
        public DateTime DueDate { get; set; }

        private Invoice CreateCopy()
        {
            Invoice invoiceCopy = new Invoice(this.Number, DateTime.Today, this.PaymentType, this.Customer, this.DueDate);

            foreach (var detal in Details)
            {
                invoiceCopy.Details.Add((InvoiceDetail)detal.Clone());
            }

            return invoiceCopy;
        }

        public decimal TotalAmount => Details.Sum(d => d.Quantity * d.Amount);

        public IList<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();

        public override string ToString()
        {
            return $"Invoice No {Number} {TotalAmount:C2} {Customer.FullName} payment method {PaymentType}";
        }

        public object Clone()
        {
            return CreateCopy();
        }

        //public object Clone()
        //{
        //   return FastDeepCloner.DeepCloner.Clone(this); // Deep Copy
        //    return MemberwiseClone(); // Shallow Copy
        //}
    }

    public enum PaymentType
    {
        Cash,
        Transfer
    }


}
