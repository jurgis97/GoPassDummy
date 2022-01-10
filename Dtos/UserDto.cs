using System;

namespace GoPassDummy.Dtos
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string MobilePhone { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}