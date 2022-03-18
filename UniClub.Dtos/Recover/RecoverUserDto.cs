using MediatR;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common;

namespace UniClub.Dtos.Recover
{
    public class RecoverUserDto : IRequest<Result>
    {
        [Required]
        public string Id { get; set; }
    }
}
