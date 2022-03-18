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
    public class UpdateClubMemberCommandHandler : IRequestHandler<UpdateClubMemberDto, int>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly IMapper _mapper;

        public UpdateClubMemberCommandHandler(IMemberRoleRepository memberRoleRepository, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubMemberDto request, CancellationToken cancellationToken)
        {
            var entity = await _memberRoleRepository.GetByIdAsync(cancellationToken, new UpdateClubMemberCommandSpecification(request));
            return await _memberRoleRepository.UpdateAsync(entity, _mapper.Map<MemberRole>(request), cancellationToken);
        }
    }
}
