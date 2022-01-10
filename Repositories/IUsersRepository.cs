using System.Collections.Generic;
using System.Threading.Tasks;
using GoPassDummy.Entities;

namespace GoPassDummy.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetUserAsync(User id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task CreateUserAsync(User item);
        Task UpdateUserAsync(User item);
        Task DeleteUserAsync(User id);
    }
}