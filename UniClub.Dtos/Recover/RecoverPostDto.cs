using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Recover
{
    public class RecoverPostDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
    }
}
