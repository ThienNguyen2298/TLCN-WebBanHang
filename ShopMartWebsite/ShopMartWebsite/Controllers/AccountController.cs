using System;
using System.Collections.Generic;
using System.Linq;
using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopMartWebsite.Data;
using ShopMartWebsite.Entities;
using ShopMartWebsite.Models;
using ShopMartWebsite.Extensions;
using ShopMartWebsite.Interfaces;

namespace ShopMartWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ShopDbContext _ctx;
        private IUserRepository _userRepository;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, 
            ShopDbContext ctx, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _ctx = ctx;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Login(string messages)
        {
            ViewData["notify"] = messages;
            var model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            if (model!=null)
            {
                var user = _userRepository.GetUserByUserName(model.UserName);
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                
                if (user.EmailConfirmed==true)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.PasswordLogin, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    if (result.IsLockedOut)
                    {

                        return new OkObjectResult(new GenericResult(false, " Tài khoản đã bị khóa"));
                    }
                    else
                    {

                        return new OkObjectResult(new GenericResult(false, " Đăng nhập sai"));
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        public IActionResult ConfirmEmail(string userid, string token)
        {
            var user = _userManager.FindByIdAsync(userid).Result;
            var result = _userManager.
                        ConfirmEmailAsync(user, token).Result;
            if (result.Succeeded)
            {
                string messages = "Email confirmed successfully!";
                return RedirectToAction("Login", "Account", messages);
            }
            else
            {
                string messages = "Error while confirming your email!";
                return RedirectToAction("Login", "Account", messages);
            }
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //var user = new User { UserName = model.Email, displayname = model.DisplayName, Email = model.Email };
            //var result = await _userManager.CreateAsync(user, model.Password);
            


            if (!_ctx.Users.Any(u => u.UserName == model.Email))
            {
                var user = new User { UserName = model.Email, displayname = model.DisplayName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userRole = new Role("User");
                    if (!_ctx.Roles.Any(x => x.Name == "User"))
                    {
                        await _roleManager.CreateAsync(userRole);
                    }
                    await _userManager.AddToRoleAsync(user, userRole.Name);
                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callBackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = code }, protocol: HttpContext.Request.Scheme);
                    //await _userManager.SetEmailAsync()
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Admin", "racingboywin1998@gmail.com"));
                    message.To.Add(new MailboxAddress("Confirm Register", user.Email));
                    message.Subject = "Xin vui lòng chạy link bên dưới để xác thực tài khoản!!!";
                    message.Body = new TextPart()
                    {
                        Text = callBackUrl
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("racingboywin1998@gmail.com", "thiendeptrai");
                        client.Send(message);
                        client.Disconnect(true);
                    };
                    ViewData["notify"] = "Vui lòng vào Email để xác nhận tài khoản!!!";
                    return View("Notify");

                }
            }
            else
            {
                string messages = "Tài khoản đã đăng ký";
                return RedirectToAction("Login", "Account", messages);
            }
            return Ok();
        }
    }
}