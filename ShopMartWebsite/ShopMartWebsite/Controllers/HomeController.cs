using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopMartWebsite.Entities;
using ShopMartWebsite.Extensions;
using ShopMartWebsite.Interfaces;
using ShopMartWebsite.Models;

namespace ShopMartWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly ICommentRepository _commentRepository;
        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository, 
            SignInManager<User> signInManager, ICommentRepository commentRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _signInManager = signInManager;
            _commentRepository = commentRepository;
        }
        public IActionResult Index(string searchTerm, int? categoryId, int? page)
        {
            int recordSize = 8;
            page = page ?? 1;
            var model = new ProductListViewModel();
            model.categoryId = categoryId;
            model.Categories = _categoryRepository.GetAllCategory();
            model.Products = _productRepository.SearchProducts(searchTerm, categoryId, page.Value, recordSize);
            //tong so cot
            int totalRecords = _productRepository.SearchProductsCount(searchTerm, categoryId);
            model.Pager = new Pager(totalRecords, page, recordSize);
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Detail(int? productId)
        {
            var model = new ProductViewModel();
            
            if (productId.HasValue)
            {
                var product = _productRepository.GetProductById(productId.Value);
                model.id = productId.Value;
                model.name = product.name;
                model.price = product.price;
                model.color = product.color;
                model.size = product.size;
                model.description = product.description;
                model.image = product.image;
                model.category = product.category;
                model.Comments = _commentRepository.GetAllCommentByProductId(productId.Value);
            }
            
            return View(model);
        }
        
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Comment(int productId, string content)
        {
            var result = false;
            if (content != null)
            {
                var model = new Comment();
                model.content = content;
                model.productId = productId;
                model.createDate = DateTime.Now;
                model.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                result = _commentRepository.SaveComment(model);
            }
            if(result == true)
                return RedirectToAction("Detail", "Home", new { productId = productId});
            else
                return RedirectToAction("Detail", "Home", new { productId = productId });
        }
        public IActionResult Reply(int commentId, string content)
        {
            return View();
        }

    }
}
