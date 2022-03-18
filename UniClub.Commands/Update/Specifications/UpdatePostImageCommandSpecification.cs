using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Specifications;

namespace UniClub.Commands.Update.Specifications
{
    public class UpdatePostImageCommandSpecification : BaseSpecification<PostImage>
    {
        public UpdatePostImageCommandSpecification(UpdatePostImageDto dto)
        {
            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
