using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetDepartmentsWithPaginationQueryHandler : IRequestHandler<GetDepartmentsWithPaginationDto, PaginatedList<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentsWithPaginationQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<DepartmentDto>> Handle(GetDepartmentsWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = await _departmentRepository.GetListAsync(cancellationToken, new GetDepartmentsWithPaginationSpecification(request));
            return new PaginatedList<DepartmentDto>(result.Items.Select(e => _mapper.Map<DepartmentDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
