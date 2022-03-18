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
    public class UpdateClubCommandHandler : IRequestHandler<UpdateClubDto, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public UpdateClubCommandHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubRepository.GetByIdAsync(cancellationToken, new UpdateClubCommandSpecification(request));
            return await _clubRepository.UpdateAsync(entity, _mapper.Map<Club>(request), cancellationToken);
        }
    }
}
