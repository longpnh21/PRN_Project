using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverClubMemberCommandHandler : IRequestHandler<RecoverClubMemberDto, int>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly IMapper _mapper;

        public RecoverClubMemberCommandHandler(IMemberRoleRepository memberRoleRepository, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverClubMemberDto request, CancellationToken cancellationToken)
        {
            var entity = await _memberRoleRepository.GetByIdAsync(cancellationToken, new RecoverClubMemberCommandSpecification(request));
            return await _memberRoleRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
