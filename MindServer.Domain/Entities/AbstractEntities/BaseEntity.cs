using System;

namespace MindServer.Domain.Entities.AbstractEntities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public BaseEntity()
        {
            CreatedDateTime = DateTime.UtcNow;
        }
    }
}