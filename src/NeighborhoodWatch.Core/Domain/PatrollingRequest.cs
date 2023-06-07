using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Http;
using MovieListAbpApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class PatrollingRequest : FullAuditedEntity<Guid>
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public Address Address { get; set; }
        public Person Person { get; set; }
    }
}
