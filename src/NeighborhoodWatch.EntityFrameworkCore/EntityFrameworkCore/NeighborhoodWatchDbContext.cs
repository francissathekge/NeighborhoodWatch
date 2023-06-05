using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NeighborhoodWatch.Authorization.Roles;
using NeighborhoodWatch.Authorization.Users;
using NeighborhoodWatch.MultiTenancy;

namespace NeighborhoodWatch.EntityFrameworkCore
{
    public class NeighborhoodWatchDbContext : AbpZeroDbContext<Tenant, Role, User, NeighborhoodWatchDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public NeighborhoodWatchDbContext(DbContextOptions<NeighborhoodWatchDbContext> options)
            : base(options)
        {
        }
    }
}
