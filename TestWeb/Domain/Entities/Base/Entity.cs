using System;
using System.ComponentModel.DataAnnotations;
using TestWeb.Interfaces.Entities;

namespace TestWeb.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
