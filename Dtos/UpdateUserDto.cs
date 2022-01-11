using System.ComponentModel.DataAnnotations;

namespace GoPassDummy.Dtos
{
    public record UpdateUserDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; init; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Surname { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }
        
        [Required]
        [Phone]
        public string MobilePhone { get; init; }
    }
}