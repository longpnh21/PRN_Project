using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Specifications;

namespace UniClub.Commands.Delete.Specifications
{
    public class DeleteEventCommandSpecification : BaseSpecification<Event>
    {
        public DeleteEventCommandSpecification(DeleteEventDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
