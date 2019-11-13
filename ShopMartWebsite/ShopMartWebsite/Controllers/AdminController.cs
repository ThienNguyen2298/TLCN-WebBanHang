using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopMartWebsite.Entities;
using ShopMartWebsite.Interfaces;

namespace ShopMartWebsite.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICategoryRepository _categoryRepository;
        public AdminController(ICategoryRepository categoryRepository, UserManager<User> userManager)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            //var model = new User();
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            //model.displayname = currentUser.Identity.Name;
            //model.displayname = user.displayname;
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "AdminLogin");

            return View();
            
        }
    }
}