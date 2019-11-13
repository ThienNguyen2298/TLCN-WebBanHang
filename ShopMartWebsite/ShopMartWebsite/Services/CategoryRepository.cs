using Microsoft.EntityFrameworkCore;
using ShopMartWebsite.Data;
using ShopMartWebsite.Entities;
using ShopMartWebsite.Interfaces;
using ShopMartWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMartWebsite.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private ShopDbContext _ctx;
        public CategoryRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public bool DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _ctx.categories.Include(cate => cate.Products).ToList();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
