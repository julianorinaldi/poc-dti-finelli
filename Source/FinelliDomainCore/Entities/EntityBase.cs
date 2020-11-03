using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinelliDomainCore.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}