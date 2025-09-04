using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Snippet : AuditableBaseEntity
    {
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string Language { get; set; } = "text";
        public string Code { get; set; } = "";
        public string? Tags { get; set; }
        public bool IsPublic { get; set; } = true;
        public string? OwnerId { get; set; }
    }
}
