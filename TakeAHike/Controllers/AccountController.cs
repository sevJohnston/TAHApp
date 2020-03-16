using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TakeAHike.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TakeAHike.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        //injects UserManager and SignInManager into the class
        public AccountController(UserManager<AppUser> userMgr,
                SignInManager<AppUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        // two versions of Login-- get and post
        //AllowAnonymous attribute allows people to open the login page
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        //userManager class allows us to authenicate and manage users
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel details,
                string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //login by email address
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    //sign them out first! to make sure they are not already signed in
                    await signInManager.SignOutAsync();
                    //sign them in
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email),
                    "Invalid user or password");
            }
            return View(details);
        }

        //Logout ends the session being used by the browser
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }

}






