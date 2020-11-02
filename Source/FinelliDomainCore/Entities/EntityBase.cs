using System;
using System.Text.Json.Serialization;

namespace FinelliDomainCore.Entities
{
    public abstract class EntityBase
    {
        [JsonIgnore]
        public string Id { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}