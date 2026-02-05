using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using ProductManagementMVC.ViewModel;
using Services;

namespace ProductManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService; // Inject your account service

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _accountService.GetAccountByEmail(model.EmailAddress);
                Console.WriteLine(user == null ? "NULL" : user.FullName);
                if (user != null && user.MemberPassword == model.MemberPassword)
                {
                    // Store user information in session
                    HttpContext.Session.SetString("UserId", user.MemberId);
                    HttpContext.Session.SetString("Username", user.FullName);

                    return RedirectToAction("Index", "Products"); // Redirect to home page
                }
                else
                {
                    Console.WriteLine("MODEL INVALID");
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                    return View(model);
                    //ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session data
            return RedirectToAction("Login");
        }
    }
}
