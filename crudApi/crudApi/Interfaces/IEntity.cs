using System;

namespace crudApi.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
