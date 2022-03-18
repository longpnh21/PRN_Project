using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetPostImagesSpecification : BaseSpecification<PostImage>
    {
        public GetPostImagesSpecification(GetPostImagesDto query)
        {
            NotApplyPagination();
        }
    }
}
