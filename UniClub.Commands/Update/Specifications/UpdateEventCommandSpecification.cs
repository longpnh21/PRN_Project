using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Specifications;

namespace UniClub.Commands.Update.Specifications
{
    public class UpdateEventCommandSpecification : BaseSpecification<Event>
    {
        public UpdateEventCommandSpecification(UpdateEventDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
