using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.ForumService.Dto
{
    [AutoMap(typeof(Forum))]

    public class ForumDto : EntityDto<Guid>
    {
        public Guid PersonId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
