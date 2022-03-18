using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Delete.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteClubMemberCommandHandler : IRequestHandler<DeleteClubMemberDto, int>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly IMapper _mapper;

        public DeleteClubMemberCommandHandler(IMemberRoleRepository memberRoleRepository, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteClubMemberDto request, CancellationToken cancellationToken)
        {
            var entity = _memberRoleRepository.GetByIdAsync(cancellationToken, new DeleteClubMemberCommandSpecification(request));
            return await _memberRoleRepository.DeleteAsync(_mapper.Map<MemberRole>(request), cancellationToken);
        }
    }
}
