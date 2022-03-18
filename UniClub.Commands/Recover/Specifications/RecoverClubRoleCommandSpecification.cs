using UniClub.Domain.Entities;
using UniClub.Dtos.Recover;
using UniClub.Specifications;

namespace UniClub.Commands.Recover.Specifications
{
    public class RecoverClubRoleCommandSpecification : BaseSpecification<ClubRole>
    {
        public RecoverClubRoleCommandSpecification(RecoverClubRoleDto dto)
        {
            SetFilterCondition(e => e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
