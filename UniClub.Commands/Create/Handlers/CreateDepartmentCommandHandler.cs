using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentDto, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDepartmentDto request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.CreateAsync(_mapper.Map<Department>(request), cancellationToken);
        }
    }
}
