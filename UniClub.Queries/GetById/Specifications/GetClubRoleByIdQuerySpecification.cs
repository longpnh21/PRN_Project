using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetClubRoleByIdQuerySpecification : BaseSpecification<ClubRole>
    {
        public GetClubRoleByIdQuerySpecification(GetClubRoleByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == e.Id);
        }
    }
}
