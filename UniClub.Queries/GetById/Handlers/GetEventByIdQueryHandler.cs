using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Queries.GetById.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetById.Handlers
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdDto, EventDto>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<EventDto> Handle(GetEventByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<EventDto>(await _eventRepository.GetByIdAsync(cancellationToken, new GetEventByIdQuerySpecification(request)));
        }
    }
}
