using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Update
{
    public class UpdateDepartmentDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int UniId { get; set; }
        public string DepName { get; set; }
        public string ShortName { get; set; }
    }
}
