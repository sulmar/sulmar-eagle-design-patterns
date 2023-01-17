namespace ProxyPattern
{
    public class ProductsController
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }

        public Product Get(int id)
        {
            Product product = _repository.Get(id);          

            return product;
        }
    }

   
}
