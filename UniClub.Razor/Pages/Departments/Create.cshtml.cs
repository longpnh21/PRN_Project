using FirebaseAdmin.Messaging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public UniversityDto University { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var claims = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "claims");
            if (claims == null)
            {
                return RedirectToPage("/Permission");
            }
            var uniId = int.Parse(claims.FirstOrDefault(c => c.Contains("university")).Split("-")[1]);
            if (uniId < 1)
            {
                return NotFound();
            }
            University = await Mediator.Send(new GetUniversityByIdDto(uniId));
            return Page();
        }
        public string Message { get; set; }
        [BindProperty]
        public CreateDepartmentDto Department { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                await Mediator.Send(Department);

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
