using AutoMapper;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Admin.Controllers.Authentication
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signinManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, SignInManager<User> signinManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _mapper = mapper;
            this.signinManager = signinManager;
        }
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Promote(string UserName)
        {
            var User = await userManager.FindByNameAsync(UserName);
            var a = await roleManager.FindByNameAsync("Admin");
            if (a == null)
            {
                var Role = new Role
                {
                    Name = "Admin",
                    Description = "Admin",
                    NormalizedName = "Admin"
                };
                await roleManager.CreateAsync(Role);
            }
            await userManager.AddToRoleAsync(User, "Admin");
            return RedirectToAction(nameof(Login));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var CheckExistence = await userManager.FindByNameAsync(signUpDto.PhoneNumber);
            if (CheckExistence != null)
            {
                ModelState.AddModelError(nameof(signUpDto.PhoneNumber), "شما قبلا ثبت نام کرده اید");
                return View(signUpDto);
            }

            //var model = signUpDto.ToEntity(_mapper);

            var User = new User()
            {
                UserName = signUpDto.PhoneNumber,
                Email = signUpDto.Email,
                PhoneNumber = signUpDto.PhoneNumber,
                Fname = signUpDto.Fname,
                Lname = signUpDto.Lname,
            };

            var Resault = await userManager.CreateAsync(User, signUpDto.PassWord);
            if (Resault.Succeeded)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                return View(signUpDto);
            }

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var findUser = await userManager.FindByNameAsync(loginDto.UserName);
            if (findUser == null)
            {
                ModelState.AddModelError(nameof(loginDto.UserName), "شما ثبت نام نکرده اید!");
                return View(loginDto);
            }
            var SignIn = await signinManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, true, lockoutOnFailure: false);
            if (SignIn.Succeeded)
            {
                await signinManager.SignInAsync(findUser, true);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                ModelState.AddModelError(nameof(loginDto.Password), "نام کاربری یا رمز شما اشتباه است");
                return View(loginDto);
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await signinManager.SignOutAsync();

            return RedirectToAction("home", "index");
        }
    }
}
