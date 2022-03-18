using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetDepartmentsWithPaginationSpecification : BaseSpecification<Department>
    {
        public GetDepartmentsWithPaginationSpecification(GetDepartmentsWithPaginationDto query) : base()
        {
            if (!query.IsDeleted)
            {
                SetFilterCondition(e => e.IsDeleted == false);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition(e => e.UniId.Equals(query.UniId)
                                    && (e.Id.ToString().Equals(query.SearchValue)
                                    || EF.Functions.Collate(e.DepName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)));
            }
            else
            {
                SetFilterCondition(e => e.UniId.Equals(query.UniId));
            }

            if ((query.OrderBy != null))
            {
                if (new Department().HasProperty(query.OrderBy.ToString()))
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
