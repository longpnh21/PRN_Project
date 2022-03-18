using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Delete.Specifications;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteClubRoleCommandHandler : IRequestHandler<DeleteClubRoleDto, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;

        public DeleteClubRoleCommandHandler(IClubRoleRepository clubRoleRepository)
        {
            _clubRoleRepository = clubRoleRepository;
        }

        public async Task<int> Handle(DeleteClubRoleDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubRoleRepository.GetByIdAsync(cancellationToken, new DeleteClubRoleCommandSpecification(request));
            return await _clubRoleRepository.DeleteAsync(entity, cancellationToken);
        }
    }
}
