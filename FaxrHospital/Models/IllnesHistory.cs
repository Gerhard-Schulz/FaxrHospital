using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FaxrHospital.Models
{
    public class IllnesHistory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Поступил")]
        public DateTime DateStart { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Выписался")]
        public DateTime DateFinish { get; set; }


        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Описание")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Анамнез")]
        public string Anamnez { get; set; }


        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Рекомендации")]
        public string Recomendations { get; set; }


        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Поциент")]
        public int PacientId { get; set; }
        [ValidateNever]
        [ForeignKey("PacientId")]
        public Pacient Pacient { get; set; }


        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Болезнь")]
        public int IllnesId { get; set; }
        [ValidateNever]
        [ForeignKey("IllnesId")]
        public Illnes Illnes { get; set; }


        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Лечащий врач")]
        public int DoctorId { get; set; }
        [ValidateNever]
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}
