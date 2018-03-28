using OnionNetCore.Core.Entities.Bases;

namespace OnionNetCore.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
