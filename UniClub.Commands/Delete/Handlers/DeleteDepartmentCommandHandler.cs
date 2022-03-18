using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Delete.Specifications;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentDto, int>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> Handle(DeleteDepartmentDto request, CancellationToken cancellationToken)
        {
            var entity = await _departmentRepository.GetByIdAsync(cancellationToken, new DeleteDepartmentCommandSpecification(request));
            return await _departmentRepository.DeleteAsync(entity, cancellationToken);
        }
    }
}
