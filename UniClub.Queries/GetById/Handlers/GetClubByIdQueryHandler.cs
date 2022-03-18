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
    public class GetClubByIdQueryHandler : IRequestHandler<GetClubByIdDto, ClubDto>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public GetClubByIdQueryHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }
        public async Task<ClubDto> Handle(GetClubByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubDto>(await _clubRepository.GetByIdAsync(cancellationToken, new GetClubByIdQuerySpecification(request)));
        }
    }
}
