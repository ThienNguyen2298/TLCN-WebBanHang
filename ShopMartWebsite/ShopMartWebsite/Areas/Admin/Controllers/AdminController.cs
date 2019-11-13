using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMartWebsite.Extensions;
using System.Security.Claims;
using ShopMartWebsite.Models;
using Microsoft.AspNetCore.Http;
using ShopMartWebsite.Interfaces;
using ShopMartWebsite.Services;
using ShopMartWebsite.Entities;
using Microsoft.AspNetCore.Identity;

namespace ShopMartWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminController(IHttpContextAccessor http, UserManager<User> userManager)
        {
            _httpContextAccessor = http;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            //var email = User.GetSpecificClaim("Email");
            //var model = new LoginViewModel();
            var model = new User();
            //var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //model.displayname = id;
            //var user = _userManager.get
            //IUserService ius = new UserService();
            //model = ius.GetUserById(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            model.displayname = user.displayname;

            return View(model);
        }
    }
}