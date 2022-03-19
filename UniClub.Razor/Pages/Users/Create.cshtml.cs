using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Razor.Filters;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.Users
{
    [AuthorizationFilter(Roles = "SystemAdministrator")]
    public class CreateModel : PageModel
    {
        public CreateModel(UserManager<Person> userManager)
        {
            _userManager = userManager;
        }
        private ISender _mediator;
        private readonly UserManager<Person> _userManager;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public PaginatedList<UniversityDto> Universities { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            await Bind();
            return Page();
        }

        [BindProperty]
        public CreateUserDto UserDto { get; set; }
        [BindProperty]
        public int UniId { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await Bind();
                    return Page();
                }

                if (!EmailValidator.IsValidEmail(UserDto.Email))
                {
                    throw new Exception("Invalid email");
                }

                var userId = await Mediator.Send(UserDto);
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await _userManager.AddClaimAsync(user, new Claim("university", UniId.ToString()));
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Message.Replace("--", "--\n");
                await Bind();
                return Page();
            }
        }

        private async Task Bind()
        {
            var dto = new GetUniversitiesWithPaginationDto();
            dto.PageSize = 1000;
            Universities = await Mediator.Send(dto);
        }
    }
}
