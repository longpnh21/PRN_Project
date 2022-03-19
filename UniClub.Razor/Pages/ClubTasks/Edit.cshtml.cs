using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Dtos.Create;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Update;

namespace UniClub.Razor.Pages.ClubTasks
{
    public class EditModel : PageModel
    {
        private ISender _mediator;
        private readonly IMapper _mapper;

        [BindProperty(SupportsGet = true)]
        public GetEventsWithPaginationDto Dto { get; set; }

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public EditModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GetClubTaskByIdDto dto = new GetClubTaskByIdDto(id.Value);
            ClubTask = _mapper.Map<UpdateClubTaskDto>(await Mediator.Send(dto));

            if (ClubTask == null)
            {
                return NotFound();
            }

            var events = await Mediator.Send(Dto);
            ViewData["EventId"] = new SelectList(events.Items, "Id", "EventName");

            return Page();
        }
        public string Message { get; set; }

        [BindProperty]
        public UpdateClubTaskDto ClubTask { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (Dto.StartDate > Dto.EndDate)
                {
                    throw new Exception("StartDate must be before EndDate");
                }

                await Mediator.Send(ClubTask);

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
