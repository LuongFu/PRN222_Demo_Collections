using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iProductRepository;
        public ProductService(IProductRepository productRepository)
        {
            iProductRepository = productRepository;
        }
        public void DeleteProduct(Product p)
        {
            iProductRepository.deleteProduct(p);
        }

        public Product GetProductById(int id)
        {
            return iProductRepository.getProductById(id);
        }

        public List<Product> GetProducts()
        {
            return iProductRepository.getProducts();
        }

        public void SaveProduct(Product p)
        {
            iProductRepository.saveProduct(p);
        }

        public void UpdateProduct(Product p)
        {
            iProductRepository.updateProduct(p);
        }
    }
}
