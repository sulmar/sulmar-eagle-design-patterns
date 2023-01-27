using System;
using System.Collections.Concurrent;

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
}
