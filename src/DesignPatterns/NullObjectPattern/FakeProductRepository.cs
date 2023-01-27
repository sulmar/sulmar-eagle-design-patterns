using System.Collections.Generic;

namespace NullObjectPattern
{
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
}
