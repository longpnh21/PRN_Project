using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetClubPeriodsWithPaginationSpecification : BaseSpecification<ClubPeriod>
    {
        public GetClubPeriodsWithPaginationSpecification(GetClubPeriodsWithPaginationDto query) : base()
        {
            if (!query.IsDeleted)
            {
                SetFilterCondition(e => e.IsDeleted == false);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition(e => e.ClubId.Equals(query.ClubId) && (e.Id.ToString().Equals(query.SearchValue)
                                        || e.Status.ToString().Equals(query.SearchValue)));
            }
            else
            {
                SetFilterCondition(e => e.ClubId.Equals(query.ClubId));
            }

            if (query.StartDate != null && query.EndDate != null)
            {
                SetFilterCondition(e => query.StartDate <= e.StartDate && e.EndDate <= query.EndDate);
            }
            else if (query.StartDate != null)
            {
                SetFilterCondition(e => query.StartDate <= e.StartDate);
            }
            else if (query.EndDate != null)
            {
                SetFilterCondition(e => e.EndDate <= query.EndDate);
            }

            if ((query.OrderBy != null))
            {
                if (new ClubPeriod().HasProperty(query.OrderBy.ToString()))
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
