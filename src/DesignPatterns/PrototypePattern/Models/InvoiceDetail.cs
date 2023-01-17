using System;

namespace PrototypePattern
{
    public class InvoiceDetail : ICloneable
    {
        public InvoiceDetail(Product product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;
            Amount = product.UnitPrice;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        //public object Clone()
        //{
        //    return new InvoiceDetail(Product, Quantity);
        //}
        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"- {Product} {Quantity} {Amount:C2}";
        }
    }


}
