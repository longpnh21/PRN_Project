using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetPostsWithPaginationSpecification : BaseSpecification<Post>
    {
        public GetPostsWithPaginationSpecification(GetPostsWithPaginationDto query) : base()
        {
            if (!query.IsDeleted)
            {
                SetFilterCondition(e => e.IsDeleted == false);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                            || e.PersonId.ToString().Equals(query.SearchValue)
                            || e.Status.ToString().Equals(query.SearchValue)
                            || EF.Functions.Collate(e.Content, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                            || e.EventId.ToString().Equals(query.SearchValue));
            }

            if ((query.OrderBy != null))
            {
                if (new Post().HasProperty(query.OrderBy.ToString()))
                {
                    ApplyOrderBy(query.OrderBy.ToString());
                    ApplyOrder(query.IsAscending);
                }
                else
                {
                    query.OrderBy = null;
                }
            }

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
