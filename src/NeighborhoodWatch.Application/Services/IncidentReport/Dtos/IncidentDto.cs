using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.IncidentReport.Dtos
{
    [AutoMap(typeof(Incident))]
    public class IncidentDto : EntityDto<Guid>
    {

        public IFormFile File { get; set; }
        public Guid ?Fileid { get; set; }
        public Guid ?AddressId { get; set; }
        public Guid ?PersonId { get; set; }
        public string IncidentType { get; set; }
        public string Comment { get; set; }
    }
}
