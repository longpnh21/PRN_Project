using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.Clubs
{
    public class EditModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public EditModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            GetClubByIdDto dto = new GetClubByIdDto(id.Value);
            Club = _mapper.Map<UpdateClubDto>(await Mediator.Send(dto));

            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }

        public string Message { get; set; }
        [BindProperty]
        public UpdateClubDto Club { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                await Mediator.Send(Club);

                return RedirectToPage("./Index", new { UniId = Club.UniId });
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
