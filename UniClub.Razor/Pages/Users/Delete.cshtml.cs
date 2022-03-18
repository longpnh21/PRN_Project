using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public DeleteModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            GetUserByIdDto dto = new GetUserByIdDto(id);
            UserDto = await Mediator.Send(dto);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public UserDto UserDto { get; set; }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            DeleteUserDto delete = new DeleteUserDto(id);
            await Mediator.Send(delete);

            return RedirectToPage("./Index");
        }
    }
}
