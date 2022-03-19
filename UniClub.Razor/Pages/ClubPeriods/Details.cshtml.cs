using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UniClub.Domain.Common.Enums;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.ClubPeriods
{

    public class DetailsModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public DetailsModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        [BindProperty]
        public ClubPeriodDto ClubPeriod { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            GetClubPeriodByIdDto dto = new GetClubPeriodByIdDto(id.Value);
            ClubPeriod = await Mediator.Send(dto);

            if (ClubPeriod == null)
            {
                return NotFound();
            }
            if (ClubPeriod.EndDate.Date < DateTime.UtcNow.Date)
            {
                ClubPeriod.Status = ClubPeriodStatus.Past;
            }
            if (ClubPeriod.EndDate.Date >= DateTime.UtcNow.Date && ClubPeriod.StartDate.Date <= DateTime.UtcNow.Date)
            {
                ClubPeriod.Status = ClubPeriodStatus.Present;
            }
            await _mediator.Send(_mapper.Map<UpdateClubPeriodDto>(ClubPeriod));
            return Page();
        }
    }
}
