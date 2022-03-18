using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Update
{
    public class UpdatePostImageDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ImageUrl { get; set; }
    }
}
