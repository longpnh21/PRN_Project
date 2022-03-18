using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Recover
{
    public class RecoverDepartmentDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
    }
}
