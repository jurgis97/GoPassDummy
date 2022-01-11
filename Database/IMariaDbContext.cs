using GoPassDummy.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoPassDummy.Database
{
    public interface IMariaDbContext
    {
        DbSet<User> Users { get; set; }
    }
}