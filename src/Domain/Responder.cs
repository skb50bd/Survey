using System;

namespace Domain
{
    public class Responder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Guid UniqueIdentifier { get; set; } = Guid.NewGuid();

        public bool HasResponded { get; set; } = false;
    }
}