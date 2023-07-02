using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Data.DataBase;
using MovieStore.Models;
using MovieStore.ViewModels;

namespace MovieStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;

        public AccountController(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        //public IActionResult Login()
        //{
        //    var model = new LoginViewModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser user = await userManager.FindByEmailAsync(loginViewModel.EmailAddress);
        //        if (user is null)
        //        {
        //            ModelState.AddModelError("", "Email or password is incorrect.");
        //        }
        //        else
        //        {
        //            var passwordCheck = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
        //            if (passwordCheck)
        //            {
        //                var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

        //                if (result.Succeeded)
        //                {
        //                    return RedirectToAction("Index", "Home");
        //                }
        //                else
        //                {
        //                    ModelState.AddModelError("", "Email or password is incorrect.");
        //                }
        //            }
        //            ModelState.AddModelError("", "Email or password is incorrect.");
        //            return View(loginViewModel);


        //        }
        //    }
        //    ModelState.AddModelError("", "Email or password is incorrect.");
        //    return View(loginViewModel);
        //}

        public IActionResult Login(string returnURL)
        {
            var model = new LoginViewModel
            {
                ReturnURL = returnURL // Add this line to populate the ReturnURL property in the model
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(loginViewModel.EmailAddress);
                if (user is null)
                {
                    ModelState.AddModelError("", "Email or password is incorrect.");
                }
                else
                {
                    var passwordCheck = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (passwordCheck)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                        if (result.Succeeded)
                        {
                            if (!string.IsNullOrEmpty(loginViewModel.ReturnURL))
                            {
                                return Redirect(loginViewModel.ReturnURL);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email or password is incorrect.");
                        }
                    }
                    ModelState.AddModelError("", "Email or password is incorrect.");
                }
            }
            return View(loginViewModel);
        }


        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                // Check if username is already taken
                var existingUser = await userManager.FindByNameAsync(registerViewModel.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Username is already taken.");
                    return View(registerViewModel);
                }

                // Check if email is already taken
                existingUser = await userManager.FindByEmailAsync(registerViewModel.EmailAddess);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email is already taken.");
                    return View(registerViewModel);
                }

                ApplicationUser userModel = new ApplicationUser();

                userModel.FullName = registerViewModel.FullName;
                userModel.UserName = registerViewModel.Username;
                userModel.PasswordHash = registerViewModel.Password;
                userModel.Email = registerViewModel.EmailAddess;
                userModel.PhoneNumber = registerViewModel.PhoneNumber;

                IdentityResult result = await userManager.CreateAsync(userModel, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, AppDbInitializer.UserRole);
                    await signInManager.SignInAsync(userModel, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(registerViewModel);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();

        }
    }
}
