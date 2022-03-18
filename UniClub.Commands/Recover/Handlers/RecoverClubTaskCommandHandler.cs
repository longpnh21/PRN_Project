using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverClubTaskCommandHandler : IRequestHandler<RecoverClubTaskDto, int>
    {
        private readonly IClubTaskRepository _clubTaskRepository;
        private readonly IMapper _mapper;

        public RecoverClubTaskCommandHandler(IClubTaskRepository clubTaskRepository, IMapper mapper)
        {
            _clubTaskRepository = clubTaskRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverClubTaskDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubTaskRepository.GetByIdAsync(cancellationToken, new RecoverClubTaskCommandSpecification(request));
            return await _clubTaskRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
