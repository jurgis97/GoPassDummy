using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoPassDummy.Repositories;
using GoPassDummy.Dtos;
using GoPassDummy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GoPassDummy.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = (await repository.GetUsersAsync())
                        .Select(user => user.AsDto());
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid id)
        {
            var user = await repository.GetUserAsync(id);

            if(user is null)
            {
                return NotFound();
            }

            return user.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto userDto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                MobilePhone = userDto.MobilePhone,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetUserAsync), new {id = user.Id}, user.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, UpdateUserDto userDto)
        {
            var existingUser = await repository.GetUserAsync(id);

            if(existingUser is null)
            {
                return NotFound();
            }

            User updatedUser = existingUser with {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                MobilePhone = userDto.MobilePhone
            };

            await repository.UpdateUserAsync(updatedUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var existingUser = await repository.GetUserAsync(id);

            if(existingUser is null)
            {
                return NotFound();
            }

            await repository.DeleteUserAsync(id);

            return NoContent();
        }
    }
}