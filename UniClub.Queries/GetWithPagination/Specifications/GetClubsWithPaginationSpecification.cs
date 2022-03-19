using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetClubsWithPaginationSpecification : BaseSpecification<Club>
    {
        public GetClubsWithPaginationSpecification(GetClubsWithPaginationDto query) : base()
        {
            if (!query.IsDeleted)
            {
                SetFilterCondition(e => e.IsDeleted == false);
            }

            if (!string.IsNullOrEmpty(query.SearchValue))
            {
                SetFilterCondition(e => (e.UniId.Equals(query.UniId)) &&
                                    (e.Id.ToString().Equals(query.SearchValue)
                                    || EF.Functions.Collate(e.ClubName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.Description, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.ShortDescription, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || e.EstablishedDate.ToString().Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.Slogan, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)));
            }
            else
            {
                SetFilterCondition(e => e.UniId.Equals(query.UniId));
            }

            AddInclude("ClubPeriods");

            if ((query.OrderBy != null))
            {
                if (new Club().HasProperty(query.OrderBy.ToString()))
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
