using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Queries.GetById.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetById.Handlers
{
    public class GetClubMemberByIdQueryHandler : IRequestHandler<GetClubMemberByIdDto, MemberRoleDto>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly IMapper _mapper;

        public GetClubMemberByIdQueryHandler(IMemberRoleRepository memberRoleRepository, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _mapper = mapper;
        }

        public async Task<MemberRoleDto> Handle(GetClubMemberByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<MemberRoleDto>(await _memberRoleRepository.GetByIdAsync(cancellationToken, new GetClubMemberByIdQuerySpecification(request)));
        }
    }
}
