using GoPassDummy.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoPassDummy
{
    public partial class MariaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        
        public MariaDbContext(DbContextOptions<MariaDbContext> options)
            : base(options)
        {

        }
    }
}