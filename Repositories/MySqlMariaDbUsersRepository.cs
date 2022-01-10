using System.Collections.Generic;
using System.Threading.Tasks;
using GoPassDummy.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoPassDummy.Repositories
{
    public class MySqlMariaDbUsersRepository : IUsersRepository
    {
        private const string databaseName = "GoPassDummy";
        private readonly MariaDbContext dbContext;

        public MySqlMariaDbUsersRepository(MariaDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public Task CreateUserAsync(User item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUserAsync(User id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserAsync(User id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUserAsync(User item)
        {
            throw new System.NotImplementedException();
        }
    }
}