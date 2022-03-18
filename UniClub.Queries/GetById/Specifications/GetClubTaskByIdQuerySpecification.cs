using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetClubTaskByIdQuerySpecification : BaseSpecification<ClubTask>
    {
        public GetClubTaskByIdQuerySpecification(GetClubTaskByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
