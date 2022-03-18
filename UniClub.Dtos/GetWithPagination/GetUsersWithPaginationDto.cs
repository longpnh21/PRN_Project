using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetUsersWithPaginationDto : RequestPaginationQuery<PersonProperties?>, IRequest<PaginatedList<UserDto>>
    {
        private Role _role;
        public override PersonProperties? OrderBy { get; set; }
        public Role GetRole() => _role;
        public void SetRole(Role role) => _role = role;
    }
}
