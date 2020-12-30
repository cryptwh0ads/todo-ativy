using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using crudApi.Interfaces;

namespace crudApi.Models
{
    public class ToDo : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public int Completed { get; set; }

        [JsonIgnore]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}
