using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Razor.Filters;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.Students
{
    [AuthorizationFilter(Roles = "SchoolAdmin")]
    public class CreateModel : PageModel
    {
        public CreateModel(UserManager<Person> userManager)
        {
            _userManager = userManager;
        }
        private ISender _mediator;
        private readonly UserManager<Person> _userManager;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public PaginatedList<DepartmentDto> Departments { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                await Bind();
                return Page();
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToPage("/Permission");
            }
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
                    await Bind();
                    return Page();
                }

                if (!EmailValidator.IsValidEmail(UserDto.Email))
                {
                    throw new Exception("Invalid email");
                }


                var userId = await Mediator.Send(UserDto);
                var user = await _userManager.FindByIdAsync(userId);

                return RedirectToPage("./Index");
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToPage("/Permission");
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
            var claims = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "claims");
            if (claims == null)
            {
                throw new UnauthorizedAccessException();
            }
            var uniId = int.Parse(claims.FirstOrDefault(c => c.Contains("university")).Split("-")[1]);
            var dto = new GetDepartmentsWithPaginationDto();
            dto.UniId = uniId;
            dto.PageSize = 1000;
            Departments = await Mediator.Send(dto);
        }
    }
}
