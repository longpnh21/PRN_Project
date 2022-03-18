using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using UniClub.Services.Interfaces;

namespace UniClub.Services
{
    public class ApplicationUploadService : IUploadService
    {
        public async Task<string> Upload(IFormFile file, string folder = "files")
        {
            string filePath = Path.Combine(folder, Path.GetRandomFileName());

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
            }
            return filePath;
        }
    }
}
