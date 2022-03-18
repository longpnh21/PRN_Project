using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;


        public LoginModel(UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public string Message { get; set; }
        [BindProperty]
        public LoginViewModel Account { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Person user = null;
            try
            {
                if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index");
                }

                if (Account.UserName.Contains("@"))
                {
                    if (!EmailValidator.IsValidEmail(Account.UserName))
                        throw new Exception("Invalid email format");
                    user = await _userManager.FindByEmailAsync(Account.UserName);
                }
                else
                {
                    user = await _userManager.FindByNameAsync(Account.UserName);
                }

                if (user == null)
                    throw new Exception("The username or email address you entered isn't connected to an account.");
                var result = await _signInManager.PasswordSignInAsync(user, Account.Password, false, false);
                if (!result.Succeeded)
                    throw new Exception("Invalid username/password");

                var roles = await _userManager.GetRolesAsync(user);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "user", user);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "roles", roles);
                return RedirectToPage("/index");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }

        public class LoginViewModel
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }
}
