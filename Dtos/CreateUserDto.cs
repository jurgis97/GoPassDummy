using System.ComponentModel.DataAnnotations;

namespace GoPassDummy.Dtos
{
    public record CreateUserDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Surname { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public string MobilePhone { get; init; }
    }
}