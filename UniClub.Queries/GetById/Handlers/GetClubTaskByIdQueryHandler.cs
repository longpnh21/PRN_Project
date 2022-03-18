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
    public class GetClubTaskByIdQueryHandler : IRequestHandler<GetClubTaskByIdDto, ClubTaskDto>
    {
        private readonly IClubTaskRepository _clubTaskRepository;
        private readonly IMapper _mapper;

        public GetClubTaskByIdQueryHandler(IClubTaskRepository clubTaskRepository, IMapper mapper)
        {
            _clubTaskRepository = clubTaskRepository;
            _mapper = mapper;
        }
        public async Task<ClubTaskDto> Handle(GetClubTaskByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubTaskDto>(await _clubTaskRepository.GetByIdAsync(cancellationToken, new GetClubTaskByIdQuerySpecification(request)));
        }
    }
}
