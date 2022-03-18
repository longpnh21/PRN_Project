using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Domain.Common;
using UniClub.Dtos.Recover;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverUserCommandHandler : IRequestHandler<RecoverUserDto, Result>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public RecoverUserCommandHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(RecoverUserDto request, CancellationToken cancellationToken)
        {
            return /*await _identityService.RecoverUserAsync(request.Id, _mapper.Map<Person>(request));*/ null;
        }
    }
}
