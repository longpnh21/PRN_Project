using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [BindProperty]
        public UserDto UserDto { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var user = SessionHelper.GetObjectFromJson<Person>(HttpContext.Session, "user");
            if (user == null)
            {
                return RedirectToPage("/Permission");
            }
            if (string.IsNullOrEmpty(user.Id))
            {
                return NotFound();
            }
            GetUserByIdDto dto = new GetUserByIdDto(user.Id);
            UserDto = await Mediator.Send(dto);
            if (UserDto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
