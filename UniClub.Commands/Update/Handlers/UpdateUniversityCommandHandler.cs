using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Update.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;
using UniClub.Services.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityDto, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public UpdateUniversityCommandHandler(IUniversityRepository universityRepository, IUploadService uploadService, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _uploadService = uploadService;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateUniversityDto request, CancellationToken cancellationToken)
        {
            string logoUrl = null;
            if (request.UploadedLogo != null && request.UploadedLogo.Length > 0)
            {
                logoUrl = await _uploadService.Upload(request.UploadedLogo, "universities");
            }
            request.LogoUrl = logoUrl;
            var entity = await _universityRepository.GetByIdAsync(cancellationToken, new UpdateUniversityCommandSpecification(request));
            return await _universityRepository.UpdateAsync(entity, _mapper.Map<University>(request), cancellationToken);
        }
    }
}
