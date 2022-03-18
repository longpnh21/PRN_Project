using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Specifications;

namespace UniClub.Commands.Delete.Specifications
{
    public class DeleteClubTaskCommandSpecification : BaseSpecification<ClubTask>
    {
        public DeleteClubTaskCommandSpecification(DeleteClubTaskDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
