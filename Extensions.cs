using GoPassDummy.Dtos;
using GoPassDummy.Entities;

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
    }
}