using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoPassDummy.Repositories;
using GoPassDummy.Dtos;
using GoPassDummy.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
            var user = await CreateSingleUser(userDto);

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

        [HttpPost("upload")]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile formFile)
        {
            if(formFile.ContentType != "text/plain")
            {
                return BadRequest("Invalid file format.");
            }
            if (formFile.Length <= 0)
            {
                return BadRequest("File is empty.");
            }
            
            var usersCreadted = new List<User>();
            List<string> fileLines = await formFile.ReadAsStringAsync();

            foreach(var line in fileLines)
            {
                var elems = line.Split(';');
                if(elems.Length !=  4) continue;

                CreateUserDto userDto = new() 
                {
                    Name = elems[0],
                    Surname = elems[1],
                    Email = elems[2],
                    MobilePhone = elems[3],
                };

                if( !Validator.TryValidateObject(userDto, new ValidationContext(userDto), null, true) )
                {
                    continue;
                }

                var user = await CreateSingleUser(userDto);

                usersCreadted.Add(user);
            }
            
            return CreatedAtAction(nameof(OnPostUploadAsync), usersCreadted.Select(user => user.AsDto()));
        }

        private async Task<User> CreateSingleUser(CreateUserDto userDto)
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

            return user;
        }
    }
}