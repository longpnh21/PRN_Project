using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverUniversityCommandHandler : IRequestHandler<RecoverUniversityDto, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public RecoverUniversityCommandHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverUniversityDto request, CancellationToken cancellationToken)
        {
            var entity = await _universityRepository.GetByIdAsync(cancellationToken, new RecoverUniversityCommandSpecification(request));
            return await _universityRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
