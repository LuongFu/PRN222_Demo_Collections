using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        void saveProduct(Product p);
        void updateProduct(Product p);
        void deleteProduct(Product p);
        List<Product> getProducts();
        Product getProductById(int id);
    }
}
