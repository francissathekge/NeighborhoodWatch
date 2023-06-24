using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.Helpers;
using NeighborhoodWatch.Services.StoredImageService.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.StoredImageService
{
    public class StoredImageAppService : ControllerBase, IStoredImageAppService
    {
        const string BASE_FILE_PATH = "App_Data/Images";
        private readonly IRepository<StoredImage, Guid> _storedFileRepository;
        private readonly IMapper _mapper;
        public StoredImageAppService(IRepository<StoredImage, Guid> storedFileRepository, IMapper mapper)
        {
            _mapper = mapper;
            _storedFileRepository = storedFileRepository;
        }
        [HttpPost, Route("Uploads")]
        [Consumes("multipart/form-data")]
        public async Task<StoredImage> CreateStoredFileImages([FromForm] StoredImageDto input)
        {
            if (!Utils.IsImage(input.Files))
                throw new ArgumentException("The file is not a valid image.");
            var checkAvailability = await _storedFileRepository.FirstOrDefaultAsync(x => x.FileNames == input.Files.FileName);
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var storedFile = _mapper.Map<StoredImage>(input);
            storedFile.FileNames = checkAvailability != null ? $"{timestamp}_{input.Files.FileName}" : input.Files.FileName;
            storedFile.FileTypes = input.Files.ContentType;
            var filePath = $"{BASE_FILE_PATH}/{input.Files.FileName}"; //png if it's an image
            using (var fileStream = input.Files.OpenReadStream())
            {
                await SaveFile(filePath, fileStream);
            }
            var test = _storedFileRepository.InsertAsync(storedFile);
            return await _storedFileRepository.InsertAsync(storedFile);
        }
        private async Task SaveFile(string filePath, Stream stream)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(fs);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetStoredFileImages(Guid id)
        {
            var storedFile = await _storedFileRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (storedFile == null)
                //return Content("filename not present");
                throw new UserFriendlyException("File not found");
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           BASE_FILE_PATH, storedFile.FileNames);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".png", "image/png"},
                {".jpg", "image/jpg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
