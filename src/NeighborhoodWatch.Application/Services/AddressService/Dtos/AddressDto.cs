using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.AddressService.Dtos
{
    [AutoMap(typeof(Address))]
    public class AddressDto : EntityDto<Guid>
    {
        public string Street { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
    }
}
