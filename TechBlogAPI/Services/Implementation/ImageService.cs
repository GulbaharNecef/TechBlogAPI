using TechBlogAPI.Entities;
using TechBlogAPI.IRepositories;
using TechBlogAPI.Services.Abstraction;

namespace TechBlogAPI.Services.Implementation
{
    public class ImageService : IImageService
    {
        private readonly IImageRepo _imageRepo;

        public ImageService(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        public async Task<Image> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new Exception("Invalid image file");
            }
            var image = new Image
            {
                Url = await SaveFileToDiskAsync(imageFile)
            };

            await _imageRepo.AddAsync(image);
            return image;
        }

        public async Task<bool> DeleteImageAsync(string imageId)
        {
            var image = await _imageRepo.GetByID(imageId);
            if (image == null)
            {
                return false;
            }

            _imageRepo.Remove(image);
            return true;
        }

        private async Task<string> SaveFileToDiskAsync(IFormFile file)
        {
            //directory nin pathi
            string _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            //yoxdursa yarat
            if (!Directory.Exists(_imageDirectory))
            {
                Directory.CreateDirectory(_imageDirectory);
            }

            //unique file name
            var filePath = Path.Combine(_imageDirectory, Guid.NewGuid() + Path.GetExtension(file.FileName));

            //  file i disk e save edir
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the file.", ex);
            }

            return filePath;           
        }
               
    }
}
