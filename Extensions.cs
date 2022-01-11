using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GoPassDummy.Dtos;
using GoPassDummy.Entities;
using Microsoft.AspNetCore.Http;

namespace GoPassDummy
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                MobilePhone = user.MobilePhone,
                CreatedDate = user.CreatedDate
            };
        }

        public static async Task<List<string>> ReadAsStringAsync(this IFormFile file)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.Add(await reader.ReadLineAsync()); 
            }
            return result;
        }
    }
}