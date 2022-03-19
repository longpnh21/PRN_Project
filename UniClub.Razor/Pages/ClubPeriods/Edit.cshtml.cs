using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Threading.Tasks;
using UniClub.Domain.Common.Enums;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Update;
using UniClub.Razor.Filters;
namespace UniClub.Razor.Pages.ClubPeriods
{
    [AuthorizationFilter(Roles = "SchoolAdmin")]
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
            GetClubPeriodByIdDto dto = new GetClubPeriodByIdDto(id.Value);
            ClubPeriod = _mapper.Map<UpdateClubPeriodDto>(await Mediator.Send(dto));

            if (ClubPeriod == null)
            {
                return NotFound();
            }
            if (ClubPeriod.EndDate.Date < DateTime.UtcNow.Date)
            {
                ClubPeriod.Status = ClubPeriodStatus.Past;
                Message = "Cannot update past club period";
            }
            if (ClubPeriod.EndDate.Date >= DateTime.UtcNow.Date && ClubPeriod.StartDate.Date <= DateTime.UtcNow.Date)
            {
                ClubPeriod.Status = ClubPeriodStatus.Present;
                Message = "Cannot update present club period";
            }
            await _mediator.Send(ClubPeriod);
            return Page();
        }

        public string Message { get; set; }
        [BindProperty]
        public UpdateClubPeriodDto ClubPeriod { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ClubPeriod.StartDate > ClubPeriod.EndDate)
            {
                Message = "StartDate must be earlier than EndDate";
                return Page();
            }
            if (ClubPeriod.StartDate.Date > DateTime.UtcNow.Date)
            {
                ClubPeriod.Status = ClubPeriodStatus.Future;
            }


            await Mediator.Send(ClubPeriod);

            return RedirectToPage("./Index", new { clubId = ClubPeriod.ClubId });
        }
    }
}
