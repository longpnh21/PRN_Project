using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [BindProperty(SupportsGet = true)]
        public GetUniversitiesWithPaginationDto Dto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var universities = await Mediator.Send(Dto);
            var universitiesAvailable = universities.Items.Where(uni => uni.IsDeleted == false).ToList();
            ViewData["UniId"] = new SelectList(universitiesAvailable, "Id", "UniName");
            return Page();
        }

        [BindProperty]
        public CreateDepartmentDto Department { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Mediator.Send(Department);

            return RedirectToPage("./Index");
        }
    }
}
