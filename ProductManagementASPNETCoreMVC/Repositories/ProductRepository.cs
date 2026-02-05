using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void saveProduct(Product p) => ProductDAO.SaveProduct(p);
        public void updateProduct(Product p) => ProductDAO.UpdateProduct(p);
        public void deleteProduct(Product p) => ProductDAO.DeleteProduct(p);
        public List<Product> getProducts() => ProductDAO.GetProducts();
        public Product getProductById(int id) => ProductDAO.GetProductById(id);
    }
}
