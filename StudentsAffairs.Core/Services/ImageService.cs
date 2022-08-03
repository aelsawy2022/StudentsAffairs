using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using StudentsAffairs.Core.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAffairs.Core.Services
{
    public class ImageService : IImageService
    {
        public static IWebHostEnvironment _environment;

        public ImageService(
            IWebHostEnvironment environment
            )
        {
            _environment = environment;
        }

        public async Task<bool> DeleteCurrentImageIfExists(string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image))
                {
                    string imagePath = Path.Combine(_environment.WebRootPath, "Upload", "Images", image);

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Upload", "Images")))
            {
                Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Upload", "Images"));
            }

            string fileName = DateTime.Now.ToString("MM-dd-yyyy_hmmsstt") + "_" + image.FileName;

            using (FileStream fileStream = System.IO.File.Create(Path.Combine(_environment.WebRootPath, "Upload", "Images", fileName)))
            {
                await image.CopyToAsync(fileStream);
                fileStream.Flush();
            }
            return fileName;
        }
    }
}
