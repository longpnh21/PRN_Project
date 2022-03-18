using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Services.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserDto, Result>
    {
        private const string DEFAULT_FEMALE_IMAGE = "https://firebasestorage.googleapis.com/v0/b/premium-client-337312.appspot.com/o/users%2Fdefaultfemaleprofile.jpg?alt=media&token=a6a7febf-1682-424f-a2e9-a37acd25c458";
        private const string DEFAULT_MALE_IMAGE = "https://firebasestorage.googleapis.com/v0/b/premium-client-337312.appspot.com/o/users%2Fdefaultmaleprofile.jpg?alt=media&token=3bf73995-3ec1-4565-8a0f-93cf540777fb8";
        private readonly IIdentityService _identityService;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IIdentityService identityService, IUploadService uploadService, IMapper mapper)
        {
            _identityService = identityService;
            _uploadService = uploadService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateUserDto request, CancellationToken cancellationToken)
        {
            string imageUrl = string.Empty;
            if (request.UploadedImage != null && request.UploadedImage.Length > 0)
            {
                imageUrl = await _uploadService.Upload(request.UploadedImage, "users");
            }
            request.ImageUrl = imageUrl;
            return await _identityService.UpdateUserAsync(request.Id, _mapper.Map<Person>(request));
        }
    }
}
