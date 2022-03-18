using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UniClub.Domain.Common.Enums;
using UniClub.Dtos.Create;

namespace UniClub.Razor.Pages.ClubPeriods
{
    public class CreateModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public IActionResult OnGet()
        {
            if (ClubId == null)
            {
                return NotFound();
            }
            return Page();
        }
        [BindProperty(SupportsGet = true)]
        public int? ClubId { get; set; }

        [BindProperty]
        public CreateClubPeriodDto ClubPeriod { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ClubId == null || ClubId < 1)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                ClubPeriod.ClubId = ClubId.Value;

                if (ClubPeriod.StartDate > ClubPeriod.EndDate)
                {
                    Message = "StartDate must be earlier than EndDate";
                    return Page();
                }
                if (ClubPeriod.StartDate.Date > DateTime.UtcNow.Date)
                {
                    ClubPeriod.Status = ClubPeriodStatus.Future;
                    await Mediator.Send(ClubPeriod);

                    return RedirectToPage("./Index", new { clubId = ClubId });
                }
                Message = "Cannot create past/present club periods";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Page();
        }
    }
}
