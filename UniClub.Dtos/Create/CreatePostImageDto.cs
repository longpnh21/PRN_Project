using MediatR;

namespace UniClub.Dtos.Create
{
    public class CreatePostImageDto : IRequest<int>
    {
        public int PostId { get; set; }
        public string ImageUrl { get; set; }
    }
}
