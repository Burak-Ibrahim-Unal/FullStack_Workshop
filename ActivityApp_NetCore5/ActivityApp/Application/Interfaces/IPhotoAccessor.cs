using System.Threading.Tasks;
using Application.Photos;
using Microsoft.AspNetCore.Http;
using Application.Photos;

namespace Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);

    }
}