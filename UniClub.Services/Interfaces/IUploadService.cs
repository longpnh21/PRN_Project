using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UniClub.Services.Interfaces
{
    public interface IUploadService
    {
        Task<string> Upload(IFormFile file, string folder = "files");
    }
}
