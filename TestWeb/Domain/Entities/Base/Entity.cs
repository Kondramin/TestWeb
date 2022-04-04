using System.ComponentModel.DataAnnotations;

namespace TestWeb.Domain.Entities.Base
{
    public abstract class Entity
    {
        [Required]
        public int Id { get; set; }
    }
}
