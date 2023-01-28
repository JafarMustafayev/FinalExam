using Bilet_3.Models;
using Bilet_3.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_3.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<IActionResult> CreateUser()
        {
            AppUser user = new AppUser
            {
                UserName= "SuperAdmin",
                Fullname = "Jafar Mustafayev"
            };

            var res = await _userManager.CreateAsync(user,"Test-123");

            return Ok(res);
        }

        public async Task<IActionResult> CreateRole () 
        {
            IdentityRole role = new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Member");

            var res = await _roleManager.CreateAsync(role);
             await _roleManager.CreateAsync(role2);

            return Ok(res);
        }

        public async Task<IActionResult> AddRole()
        {
            AppUser user = await _userManager.FindByNameAsync("SuperAdmin");
            var res = await _userManager.AddToRoleAsync(user, "SuperAdmin");

            return Ok(res);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login,string? returnUrl)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(login.UserName);

            if (user is null)
            {
                ModelState.AddModelError("", "Username ve ya password yalnisdir");
                return View();
            }

            var res = await _signInManager.PasswordSignInAsync(user,login.Password,false,false);

            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Username ve ya password yalnisdir");
                return View();
            }

            return  RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {s
            if (!ModelState.IsValid)return View();
            AppUser user = await _userManager.FindByEmailAsync(register.Email);

            if (user!=null)
            {
                ModelState.AddModelError("Email", "bu email movcutdur yeni bir email yazin");
                return View();
            }

            user = await _userManager.FindByNameAsync(register.Username);
            if (user is not  null)
            {
                ModelState.AddModelError("Username", "bu Username movcutdur yeni bir email yazin");
                return View();

            }


            if (user is not null)
            {
                var res = await _userManager.CreateAsync(user, register.Password);
                if (res.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "SuperAdmin");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(register);
        }

    }
}
