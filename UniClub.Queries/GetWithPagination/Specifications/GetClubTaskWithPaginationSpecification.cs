using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetClubTaskWithPaginationSpecification : BaseSpecification<ClubTask>
    {
        public GetClubTaskWithPaginationSpecification(GetClubTasksWithPaginationDto query) : base()
        {
            if (!query.IsDeleted)
            {
                SetFilterCondition(e => e.IsDeleted == false);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                                    || e.EventId.ToString().Equals(query.SearchValue)
                                    || e.Status.ToString().Equals(query.SearchValue)
                                    || EF.Functions.Collate(e.TaskName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.Description, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue));

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
                if (new ClubTask().HasProperty(query.OrderBy.ToString()))
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
