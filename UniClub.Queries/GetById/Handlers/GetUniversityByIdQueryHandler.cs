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
    public class GetUniversityByIdQueryHandler : IRequestHandler<GetUniversityByIdDto, UniversityDto>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetUniversityByIdQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }
        public async Task<UniversityDto> Handle(GetUniversityByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UniversityDto>(await _universityRepository.GetByIdAsync(cancellationToken, new GetUniversityByIdQuerySpecification(request)));
        }
    }
}
