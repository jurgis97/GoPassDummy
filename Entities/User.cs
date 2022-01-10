using System;

namespace GoPassDummy.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}