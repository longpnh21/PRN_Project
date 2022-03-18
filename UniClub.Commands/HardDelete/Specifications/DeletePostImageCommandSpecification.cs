using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Specifications;

namespace UniClub.Commands.HardDelete.Specifications
{
    public class DeletePostImageCommandSpecification : BaseSpecification<PostImage>
    {
        public DeletePostImageCommandSpecification(DeletePostImageDto dto)
        {
            SetFilterCondition(e => e.Id == e.Id);
        }
    }
}
