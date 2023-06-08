using Abp.Domain.Entities.Auditing;
using MovieListAbpApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class Forum : FullAuditedEntity<Guid>
    {
        public Person Person { get; set; }
        public virtual string Content { get; set; }

    }
}
