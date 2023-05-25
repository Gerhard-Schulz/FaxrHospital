using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaxrHospital.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "ФИО")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Специальность")]
        public string Speciality { get; set; }

        [Display(Name = "Квалификация")]
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Qualification { get; set; }

        [Display(Name = "Номер отделения")]
        [Required(ErrorMessage = "Обязательное поле!")]
        public int OtdelenieId { get; set; }
        [ValidateNever]
        [ForeignKey("OtdelenieId")]
        public Otdelenie Otdelenie { get; set; }
    }
}
