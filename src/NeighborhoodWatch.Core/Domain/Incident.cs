﻿using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using MovieListAbpApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Domain
{
    public class Incident : FullAuditedEntity<Guid>
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual StoredFile Picture { get; set; }
        public Address Address { get; set; }
        public Person Person { get; set; }
        public virtual string IncidentType { get; set; }
        public virtual string Comment { get; set; }
    }
}
