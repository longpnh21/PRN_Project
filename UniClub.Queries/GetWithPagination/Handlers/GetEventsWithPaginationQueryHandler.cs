using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetEventsWithPaginationQueryHandler : IRequestHandler<GetEventsWithPaginationDto, PaginatedList<EventDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventsWithPaginationQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EventDto>> Handle(GetEventsWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = await _eventRepository.GetListAsync(cancellationToken, new GetEventsWithPaginationSpecification(request));
            return new PaginatedList<EventDto>(result.Items.Select(e => _mapper.Map<EventDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
