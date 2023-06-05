using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class Address : FullAuditedEntity<Guid>
    {
        public virtual string Street { get; set; }
        public virtual string Town { get; set; }
        public virtual string City { get; set; }
        public virtual string Province { get; set; }
        public virtual string PostalCode { get; set; }
    }
}
