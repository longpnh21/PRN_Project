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
    public class UpdateClubTaskCommandHandler : IRequestHandler<UpdateClubTaskDto, int>
    {
        private readonly IClubTaskRepository _clubTaskRepository;
        private readonly IMapper _mapper;

        public UpdateClubTaskCommandHandler(IClubTaskRepository clubTaskRepository, IMapper mapper)
        {
            _clubTaskRepository = clubTaskRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubTaskDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubTaskRepository.GetByIdAsync(cancellationToken, new UpdateClubTaskCommandSpecification(request));
            return await _clubTaskRepository.UpdateAsync(entity, _mapper.Map<ClubTask>(request), cancellationToken);
        }
    }
}
