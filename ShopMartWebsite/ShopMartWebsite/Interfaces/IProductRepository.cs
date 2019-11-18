using ShopMartWebsite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMartWebsite.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        IEnumerable<Product> SearchProducts(string searchTerm, int? categoryId, int page, int recordSize);
        bool SaveProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        IEnumerable<Product> GetAllProduct();
        int SearchProductsCount(string searchTerm, int? categoryId);
    }
}
