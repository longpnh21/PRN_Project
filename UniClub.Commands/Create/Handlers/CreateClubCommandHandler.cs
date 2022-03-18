using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;
using UniClub.Services.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubCommandHandler : IRequestHandler<CreateClubDto, int>
    {
        private readonly string DEFAULT_AVATAR = "https://firebasestorage.googleapis.com/v0/b/premium-client-337312.appspot.com/o/clubs%2Fdefaultavatar.jpg?alt=media&token=e144e791-be13-458d-850c-252df78f3f34";
        private readonly IClubRepository _clubRepository;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public CreateClubCommandHandler(IClubRepository clubRepository, IUploadService uploadService, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _uploadService = uploadService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubDto request, CancellationToken cancellationToken)
        {
            string avatarUrl = DEFAULT_AVATAR;
            if (request.UploadedAvatar != null && request.UploadedAvatar.Length > 0)
{
                avatarUrl = await _uploadService.Upload(request.UploadedAvatar, "clubs");
            }
            request.AvatarUrl = avatarUrl;
            return await _clubRepository.CreateAsync(_mapper.Map<Club>(request), cancellationToken);
        }
    }
}
