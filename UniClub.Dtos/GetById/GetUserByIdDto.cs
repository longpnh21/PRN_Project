using MediatR;
using UniClub.Domain.Common.Enums;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetUserByIdDto : IRequest<UserDto>
    {
        private Role _role;
        public string Id { get; }
        public GetUserByIdDto(string id, Role role)
        {
            Id = id;
            _role = role;
        }
        public Role GetRole() => _role;

    }
}
