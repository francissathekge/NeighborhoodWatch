using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class SecurityCompany : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string ContactNumber { get; set; }
        public virtual int NunberOFAvailableGuards { get; set; }
        public virtual double RatePerDay { get; set; }
    }
}
