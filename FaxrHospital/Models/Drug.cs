using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaxrHospital.Models
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Болезнь")]
        [Required(ErrorMessage = "Обязательное поле!")]
        public int IllnesId { get; set; }
        [ValidateNever]
        [ForeignKey("IllnesId")]
        public Illnes Illnes { get; set; }
    }
}
