using UniClub.Domain.Entities;
using UniClub.Dtos.Recover;
using UniClub.Specifications;

namespace UniClub.Commands.Recover.Specifications
{
    public class RecoverClubCommandSpecification : BaseSpecification<Club>
    {
        public RecoverClubCommandSpecification(RecoverClubDto dto)
        {
            SetFilterCondition(e => e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
