using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetStudentByIdQuerySpecification : BaseSpecification<Person>
    {
        public GetStudentByIdQuerySpecification(GetUserByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);
            SetFilterCondition(e => e.Id == dto.Id);
            AddInclude(e => e.Dep);
        }
    }
}
