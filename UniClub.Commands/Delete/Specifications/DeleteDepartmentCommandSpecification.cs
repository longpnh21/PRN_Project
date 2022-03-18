using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Specifications;

namespace UniClub.Commands.Delete.Specifications
{
    public class DeleteDepartmentCommandSpecification : BaseSpecification<Department>
    {
        public DeleteDepartmentCommandSpecification(DeleteDepartmentDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
