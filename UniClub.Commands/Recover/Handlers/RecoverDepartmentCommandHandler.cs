using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverDepartmentCommandHandler : IRequestHandler<RecoverDepartmentDto, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public RecoverDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverDepartmentDto request, CancellationToken cancellationToken)
        {
            var entity = await _departmentRepository.GetByIdAsync(cancellationToken, new RecoverDepartmentCommandSpecification(request));
            return await _departmentRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
