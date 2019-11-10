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

namespace ShopMartWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminController(IHttpContextAccessor http)
        {
            _httpContextAccessor = http;
        }
        
        public IActionResult Index()
        {
            //var email = User.GetSpecificClaim("Email");
            var model = new LoginViewModel();
             model.UserName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            

            return View(model);
        }
    }
}