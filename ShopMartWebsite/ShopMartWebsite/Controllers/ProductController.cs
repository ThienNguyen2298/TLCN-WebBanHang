using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMartWebsite.Interfaces;
using ShopMartWebsite.Models;

namespace ShopMartWebsite.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index(string searchTerm, int? categoryId, int? page)
        {
            int recordSize = 4;
            page = page ?? 1;
            var model = new ProductListViewModel();
            model.categoryId = categoryId;
            model.Products = _productRepository.SearchProducts(searchTerm, categoryId, page.Value, recordSize);
            model.Categories = _categoryRepository.GetAllCategory();
            //tong so cot
            int totalRecords = _productRepository.SearchProductsCount(searchTerm, categoryId);
            model.Pager = new Pager(totalRecords, page, recordSize);

            return View(model);
        }
        
        public IActionResult Viewss(int ID)
        {
            var model = _productRepository.GetProductById(ID);
            return PartialView("_View",model);
        }
        public IActionResult Action(int? ID)
        {
            return PartialView("_Action");
        }
        [HttpPost]
        public IActionResult Action()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return PartialView("_Delete");
        }
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            return View();
        }
    }
}