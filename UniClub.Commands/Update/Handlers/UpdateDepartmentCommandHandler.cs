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
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentDto, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateDepartmentDto request, CancellationToken cancellationToken)
        {
            var entity = await _departmentRepository.GetByIdAsync(cancellationToken, new UpdateDepartmentCommandSpecification(request));
            return await _departmentRepository.UpdateAsync(entity, _mapper.Map<Department>(request), cancellationToken);
        }
    }
}
