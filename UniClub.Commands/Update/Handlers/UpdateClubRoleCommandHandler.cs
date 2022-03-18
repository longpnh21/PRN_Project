using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Update.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateClubRoleCommandHandler : IRequestHandler<UpdateClubRoleDto, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public UpdateClubRoleCommandHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubRoleDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubRoleRepository.GetByIdAsync(cancellationToken, new UpdateClubRoleCommandSpecification(request));
            return await _clubRoleRepository.UpdateAsync(entity, _mapper.Map<ClubRole>(request), cancellationToken);
        }
    }
}
