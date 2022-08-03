using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAffairs.Core.IServices
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile image);
        Task<bool> DeleteCurrentImageIfExists(string image);
    }
}
