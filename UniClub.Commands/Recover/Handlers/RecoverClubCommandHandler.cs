using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverClubCommandHandler : IRequestHandler<RecoverClubDto, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public RecoverClubCommandHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverClubDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubRepository.GetByIdAsync(cancellationToken, new RecoverClubCommandSpecification(request));
            return await _clubRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
