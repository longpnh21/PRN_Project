using MediatR;
using UniClub.Dtos.Response;
namespace UniClub.Dtos.GetById
{
    public class GetPostByIdDto : IRequest<PostDto>
    {
        public int Id { get; }
        public GetPostByIdDto(int id)
        {
            Id = id;
        }
    }
}
