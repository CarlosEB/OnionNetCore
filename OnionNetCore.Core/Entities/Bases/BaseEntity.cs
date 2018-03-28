using System;
using OnionNetCore.Core.Interfaces.Bases;

namespace OnionNetCore.Core.Entities.Bases
{
    public abstract class BaseEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime CreatedAt { get ; set; }
        public DateTime? UpdatedAt { get; set; }        
    }

    public abstract class BaseEntity : BaseEntity<int>, IBaseEntity
    {
    }
}
