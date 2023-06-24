using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.StoredImageService.Dtos
{
    [AutoMap(typeof(StoredImage))]
    public class StoredImageDto : EntityDto<Guid?>
    {
        public IFormFile Files { get; set; }
    }
}
