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
    public class GetClubRoleByIdQueryHandler : IRequestHandler<GetClubRoleByIdDto, ClubRoleDto>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public GetClubRoleByIdQueryHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }
        public async Task<ClubRoleDto> Handle(GetClubRoleByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubRoleDto>(await _clubRoleRepository.GetByIdAsync(cancellationToken, new GetClubRoleByIdQuerySpecification(request)));
        }
    }
}
