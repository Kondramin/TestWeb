using System;
using System.ComponentModel.DataAnnotations;
using TestWeb.Domain.Entities.Base;

namespace TestWeb.Domain.Entities
{
    public class News : Entity
    {
        public News() => CreatedData = DateTime.UtcNow;

        [Required]
        public string CodeWord { get; set; }


        [Display(Name = "Название новости (заголовок)")]
        public string Title { get; set; } = "Заголовок по умолчанию";


        [Display(Name = "Содержание новости")]
        public string Text { get; set; } = "Текст новости по умолчанию";

        [Display(Name = "Дата создания новости")]
        [DataType(DataType.Time)]
        public DateTime CreatedData { get; set; }
    }
}
