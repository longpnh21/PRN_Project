using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetUniversitiesWithPaginationSpecification : BaseSpecification<University>
    {
        public GetUniversitiesWithPaginationSpecification(GetUniversitiesWithPaginationDto query)
        {
            if (!query.IsDeleted)
            {
                SetFilterCondition(e => e.IsDeleted == false);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition((e => e.Id.ToString().Equals(query.SearchValue)
                                        || EF.Functions.Collate(e.UniName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || e.ShortName.Contains(query.SearchValue)
                                        || e.EstablishedDate.ToString().Equals(query.SearchValue)
                                        || e.UniPhone.Contains(query.SearchValue)
                                        || e.Website.Contains(query.SearchValue)
                                        || EF.Functions.Collate(e.UniAddress, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)));
            }
            if ((query.OrderBy != null))
            {
                if (new University().HasProperty(query.OrderBy.ToString()))
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
