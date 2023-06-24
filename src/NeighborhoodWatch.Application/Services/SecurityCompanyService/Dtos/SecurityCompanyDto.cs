using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.SecurityCompanyService.Dtos
{
    [AutoMap(typeof(SecurityCompany))]

    public class SecurityCompanyDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int NunberOFAvailableGuards { get; set; }
        public double RatePerDay { get; set; }
    }
}
