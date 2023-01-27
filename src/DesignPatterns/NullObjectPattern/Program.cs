using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NullObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Null Object Pattern!");

            NullObjectTest();

            RealObjectTest();

        }

        private static void NullObjectTest()
        {
            IProductRepository productRepository = new FakeProductRepository();

            ProductBase product = productRepository.Get(3);

            Console.WriteLine(product.Name);
            product.RateId(3);
        }

        private static void RealObjectTest()
        {
            IProductRepository productRepository = new FakeProductRepository();

            ProductBase product = productRepository.Get(1);

            Console.WriteLine(product.Name);
            product.RateId(3);
        }
    }

    public interface IProductRepository
    {
        ProductBase Get(int id);
    }

    public class FakeProductRepository : IProductRepository
    {
        private readonly Dictionary<int, Product> products = new();

        private readonly ProductBase NotFound = ProductBase.Null;

        public FakeProductRepository()
        {
            products = new Dictionary<int, Product>
            {
                [1] = new Product {  Id = 1, Name = "DELL Laptop"  },
                [2] = new Product {  Id = 2, Name = "Apple Laptop" },
            };
        }

        public ProductBase Get(int id)
        {
            ProductBase product = products.GetValueOrDefault(id);

            return product ?? NotFound;
        }
    }

    // Abstract Object
    public abstract class ProductBase
    {
        protected int rate;

        public int Id { get; set; }
        public string Name { get; set; }

        public abstract void RateId(int rate);

        public static readonly ProductBase Null = new NullProduct();

        // Null Object
        private class NullProduct : ProductBase
        {
            public NullProduct()
            {
                Id = -1;
                Name = "Not Available";
            }

            public override void RateId(int rate)
            {
                // nic nie rób
            }
        }
    }

    // Real Object
    public class Product : ProductBase 
    {        
        public override void RateId(int rate)
        {
            this.rate = rate;
        }

    }
}
