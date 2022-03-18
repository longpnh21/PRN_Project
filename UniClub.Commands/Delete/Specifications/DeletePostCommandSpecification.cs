using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Specifications;

namespace UniClub.Commands.Delete.Specifications
{
    public class DeletePostCommandSpecification : BaseSpecification<Post>
    {
        public DeletePostCommandSpecification(DeletePostDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
