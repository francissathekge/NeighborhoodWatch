using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.DonationService.Dtos
{
    [AutoMap(typeof(Donation))]

    public class DonationDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public int PhoneNumber { get; set; }
        public string Comment { get; set; }
        public double Amount { get; set; }
    }
}
