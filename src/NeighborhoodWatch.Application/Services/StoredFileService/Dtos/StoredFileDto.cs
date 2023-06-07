﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.StoredFileService.Dtos
{
    [AutoMap(typeof(StoredFile))]
    public class StoredFileDto : EntityDto<Guid?>
    {
        public IFormFile File { get; set; }
    }
}