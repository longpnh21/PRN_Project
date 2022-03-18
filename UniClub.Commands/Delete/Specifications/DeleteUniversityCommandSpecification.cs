using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Specifications;

namespace UniClub.Commands.Delete.Specifications
{
    public class DeleteUniversityCommandSpecification : BaseSpecification<University>
    {
        public DeleteUniversityCommandSpecification(DeleteUniversityDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
