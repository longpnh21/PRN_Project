using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverClubRoleCommandHandler : IRequestHandler<RecoverClubRoleDto, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public RecoverClubRoleCommandHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverClubRoleDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubRoleRepository.GetByIdAsync(cancellationToken, new RecoverClubRoleCommandSpecification(request));
            return await _clubRoleRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
