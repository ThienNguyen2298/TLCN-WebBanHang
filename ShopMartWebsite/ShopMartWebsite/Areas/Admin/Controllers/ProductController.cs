using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMartWebsite.Entities;

namespace ShopMartWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var model = new User();
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            model.displayname = currentUser.Identity.Name;

            return View(model);
            
        }
    }
}