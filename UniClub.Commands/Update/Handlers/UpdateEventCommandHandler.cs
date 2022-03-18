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
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventDto, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IUploadService uploadService, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _uploadService = uploadService;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateEventDto request, CancellationToken cancellationToken)
        {
            var entity = await _eventRepository.GetByIdAsync(cancellationToken, new UpdateEventCommandSpecification(request));
            string imageUrl = null;
            if (request.UploadedImage != null && request.UploadedImage.Length > 0)
            {
                imageUrl = await _uploadService.Upload(request.UploadedImage, "events");
            }
            request.ImageUrl = imageUrl;
            return await _eventRepository.UpdateAsync(entity, _mapper.Map<Event>(request), cancellationToken);
        }
    }
}
