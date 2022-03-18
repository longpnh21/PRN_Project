using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Update;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.Users
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
        public async Task<IActionResult> OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            GetUserByIdDto dto = new GetUserByIdDto(id);
            UserDto = _mapper.Map<UpdateUserDto>(await Mediator.Send(dto));

            if (UserDto == null)
            {
                return NotFound();
            }
            return Page();
        }
        public string Message { get; set; }

        [BindProperty]
        public UpdateUserDto UserDto { get; set; }
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
