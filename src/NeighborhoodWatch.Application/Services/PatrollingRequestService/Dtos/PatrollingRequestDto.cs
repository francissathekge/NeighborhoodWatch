using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.PatrollingRequestService.Dtos
{
    [AutoMap(typeof(PatrollingRequest))]
    public class PatrollingRequestDto : EntityDto<Guid>
    {
        public int Period { get; set; }
        public int NoOfGuards { get; set; }
        public string Location { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid AddressId { get; set; }
        public Guid PersonId { get; set; }
    }
}
