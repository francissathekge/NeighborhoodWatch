using Abp.Domain.Entities.Auditing;
using MovieListAbpApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class Reward : FullAuditedEntity<Guid>
    {
        public virtual StoredImage Picture { get; set; }
        public Person Person { get; set; }
        public virtual DateTime RewardDate { get; set; }
        public virtual double RewardAmount { get; set; }
        public virtual string IncidentType { get; set; }
        public virtual string Comment { get; set; }

    }
}
