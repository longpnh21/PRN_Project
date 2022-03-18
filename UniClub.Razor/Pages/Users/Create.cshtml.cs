using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.Users
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateUserDto UserDto { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (EmailValidator.IsValidEmail(UserDto.Email))
                {
                    throw new Exception("Invalid email");
                }
                await Mediator.Send(UserDto);

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Message.Replace("--", "--\n");
                return Page();
            }
        }
    }
}
