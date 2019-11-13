using ShopMartWebsite.Entities;
using ShopMartWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMartWebsite.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);
        bool SaveCategory(Category product);
        bool UpdateCategory(Category product);
        bool DeleteCategory(int id);
        IEnumerable<Category> GetAllCategory();
    }
}
