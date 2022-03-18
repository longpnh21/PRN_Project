using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Recover
{
    public class RecoverClubTaskDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
    }
}
