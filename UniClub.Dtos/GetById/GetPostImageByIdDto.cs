using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetPostImageByIdDto : IRequest<PostImageDto>
    {
        public int Id { get; }
        public GetPostImageByIdDto(int id)
        {
            Id = id;
        }
    }
}
