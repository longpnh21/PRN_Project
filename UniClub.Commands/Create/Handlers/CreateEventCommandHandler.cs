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
    public class CreateEventDtoQueryHandler : IRequestHandler<CreateEventDto, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public CreateEventDtoQueryHandler(IEventRepository eventRepository, IUploadService uploadService, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _uploadService = uploadService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEventDto request, CancellationToken cancellationToken)
        {
            string imageUrl = null;
            if (request.UploadedImage != null && request.UploadedImage.Length > 0)
            {
                imageUrl = await _uploadService.Upload(request.UploadedImage, "events");
            }
            request.ImageUrl = imageUrl;
            return await _eventRepository.CreateAsync(_mapper.Map<Event>(request), cancellationToken);
        }
    }
}
