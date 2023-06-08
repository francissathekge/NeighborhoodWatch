using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NeighborhoodWatch.Authorization.Roles;
using NeighborhoodWatch.Authorization.Users;
using NeighborhoodWatch.MultiTenancy;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;

namespace NeighborhoodWatch.EntityFrameworkCore
{
    public class NeighborhoodWatchDbContext : AbpZeroDbContext<Tenant, Role, User, NeighborhoodWatchDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PatrollingRequest> PatrollingRequests { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<StoredFile> StoredFiles { get; set; }
        public DbSet<Forum> Forums { get; set; }


        public NeighborhoodWatchDbContext(DbContextOptions<NeighborhoodWatchDbContext> options)
            : base(options)
        {
        }
    }
}
