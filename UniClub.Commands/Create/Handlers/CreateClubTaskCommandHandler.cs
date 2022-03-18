using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubTaskCommandHandler : IRequestHandler<CreateClubTaskDto, int>
    {
        private readonly IClubTaskRepository _universityRepository;
        private readonly IMapper _mapper;

        public CreateClubTaskCommandHandler(IClubTaskRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubTaskDto request, CancellationToken cancellationToken)
        {
            return await _universityRepository.CreateAsync(_mapper.Map<ClubTask>(request), cancellationToken);
        }
    }
}
