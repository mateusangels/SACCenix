using Backend.Domain.Interfaces;

namespace Backend.Domain.Entities
{
    public abstract class BaseEntity : IAuditable, ISoftDelete
    {
        public int Id { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public DateTime? Deleted_At { get; set; }

    }
}
