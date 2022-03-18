using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetClubRolesWithPaginationSpecification : BaseSpecification<ClubRole>
    {
        public GetClubRolesWithPaginationSpecification(GetClubRolesWithPaginationDto query) : base()
        {
            if (!query.IsDeleted)
            {
                SetFilterCondition(e => e.IsDeleted == false);
            }


            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                                        || EF.Functions.Collate(e.Role, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || e.ReportToRoleId.ToString().Equals(query.SearchValue));
            }

            if ((query.OrderBy != null))
            {
                if (new ClubRole().HasProperty(query.OrderBy.ToString()))
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
