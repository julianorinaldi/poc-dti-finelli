using FinelliDomainCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace FinelliDomainMonolito
{
    public class Brand : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Decription { get; set; }
    }
}