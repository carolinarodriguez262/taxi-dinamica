﻿namespace TaxiDinamica.Services.Cloudinary
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
        Task<string> UploadRawAsync(IFormFile rawFile, string fileName);
    }
}
