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
        private readonly IReplyRepository _replyRepository;
        private readonly IOrderRepository _orderRepository;
        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository, 
            SignInManager<User> signInManager, ICommentRepository commentRepository, IReplyRepository replyRepository,
            IOrderRepository orderRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _signInManager = signInManager;
            _commentRepository = commentRepository;
            _replyRepository = replyRepository;
            _orderRepository = orderRepository;
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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { productId = productId });
            }
            else {
                if (content != null)
                {
                    var model = new Comment();
                    model.content = content;
                    model.productId = productId;
                    model.createDate = DateTime.Now;
                    model.status = true;
                    model.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    result = _commentRepository.SaveComment(model);
                }
                if (result == true)
                    return RedirectToAction("Detail", "Home", new { productId = productId });
                else
                    return RedirectToAction("Detail", "Home", new { productId = productId });
            }
        }
        public IActionResult Reply(int commentId, string content, int productId)
        {
            var result = false;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { productId = productId });
            }
            else
            {
                if (content != null)
                {
                    var model = new Reply();
                    model.content = content;
                    model.commentId = commentId;
                    model.createDate = DateTime.Now;
                    model.status = true;
                    model.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    result = _replyRepository.SaveReply(model);
                }
                if (result == true)
                    return RedirectToAction("Detail", "Home", new { productId = productId });
                else
                    return RedirectToAction("Detail", "Home", new { productId = productId });
            }
        }
        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCart(OrderDetail[] arr, string customer, string info, string address, string note, decimal total)
        {
            JsonResult json;
            var result = false;
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = new Order() { customer=customer, info=info, address=address, createDate=DateTime.Now, note=note, status=true, total=total, OrderDetails=arr, userId=userId};
            result = _orderRepository.SaveOrder(order);
            if (result)
            {
                json = new JsonResult(new { Success = true });
            }
            else
            {
                json = new JsonResult(new { Success = false });

            }
            return json;
            
            
        }

    }
}
