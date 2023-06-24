using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.RewardService.Dtos
{
    [AutoMap(typeof(Reward))]
    public class RewardDto : EntityDto<Guid>
    {
        public IFormFile File { get; set; }
        public Guid? PersonId { get; set; }
        public DateTime RewardDate { get; set; }
        public double RewardAmount { get; set; }
        public string IncidentType { get; set; }
        public string Comment { get; set; }
    }
}
