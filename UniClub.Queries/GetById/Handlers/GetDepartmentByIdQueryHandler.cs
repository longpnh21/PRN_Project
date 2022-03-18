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
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdDto, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DepartmentDto>(await _departmentRepository.GetByIdAsync(cancellationToken, new GetDepartmentByIdQuerySpecification(request)));
        }
    }
}
