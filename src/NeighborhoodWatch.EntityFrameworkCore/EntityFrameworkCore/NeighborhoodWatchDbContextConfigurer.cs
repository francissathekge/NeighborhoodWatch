using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NeighborhoodWatch.EntityFrameworkCore
{
    public static class NeighborhoodWatchDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NeighborhoodWatchDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NeighborhoodWatchDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
