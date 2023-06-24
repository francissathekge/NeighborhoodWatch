using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class Donation : FullAuditedEntity<Guid>
    {
        public virtual string Title { get; set; }
        public virtual int PhoneNumber { get; set; }
        public virtual string Comment { get; set; }
        public virtual double Amount { get; set; }
    }
}
