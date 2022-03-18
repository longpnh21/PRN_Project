using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.Users
{
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public PaginatedList<UserDto> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetUsersWithPaginationDto Dto { get; set; }

        public async Task OnGetAsync()
        {
            Users = await Mediator.Send(Dto);
        }
    }
}
