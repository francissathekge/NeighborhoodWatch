using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class StoredImage : Entity<Guid>
    {
        [NotMapped]
        public virtual IFormFile Files { get; set; }
        public virtual string FileNames { get; set; }
        public virtual string FileTypes { get; set; }
    }
}
 