using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverEventCommandHandler : IRequestHandler<RecoverEventDto, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public RecoverEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverEventDto request, CancellationToken cancellationToken)
        {
            var entity = await _eventRepository.GetByIdAsync(cancellationToken, new RecoverEventCommandSpecification(request));
            return await _eventRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
