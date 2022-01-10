using GoPassDummy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GoPassDummy.Database
{
    public partial class MariaDbContext : Microsoft.EntityFrameworkCore.DbContext, IMariaDbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected readonly IConfiguration Configuration;

        public MariaDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("MariaDbConnectionString");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}