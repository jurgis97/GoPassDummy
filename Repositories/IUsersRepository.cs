using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoPassDummy.Entities;

namespace GoPassDummy.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task CreateUserAsync(User item);
        Task UpdateUserAsync(User item);
        Task DeleteUserAsync(Guid id);
    }
}