using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoPassDummy.Database;
using GoPassDummy.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoPassDummy.Repositories
{
    public class MySqlMariaDbUsersRepository : IUsersRepository
    {
        private readonly MariaDbContext dbContext;

        public MySqlMariaDbUsersRepository(IMariaDbContext dbContext)
        {
            this.dbContext = (MariaDbContext)dbContext; 
        }

        public async Task CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var entity = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            dbContext.Users.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var entity = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == user.Id);
            dbContext.Entry(entity).CurrentValues.SetValues(user);
            await dbContext.SaveChangesAsync();
        }
    }
}