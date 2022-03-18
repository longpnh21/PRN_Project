using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubRoleCommandHandler : IRequestHandler<CreateClubRoleDto, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public CreateClubRoleCommandHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubRoleDto request, CancellationToken cancellationToken)
        {
            return await _clubRoleRepository.CreateAsync(_mapper.Map<ClubRole>(request), cancellationToken);
        }
    }
}
