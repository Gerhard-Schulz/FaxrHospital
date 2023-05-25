using System.ComponentModel.DataAnnotations;

namespace FaxrHospital.Models
{
    public class Pacient
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "ФИО")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Пол")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [MaxLength(10, ErrorMessage = "Не может превышать {1} цыфр")]
        [Display(Name = "Номер и Серия Паспорта")]
        public string Passport { get; set; }

        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Обязательное поле!")]
        [MaxLength(11, ErrorMessage = "Номер телефона не может превышать {1} цыфр")]
        [MinLength(7, ErrorMessage = "Номер телефона не может быть меньше {1} цыфр")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Дата Рождения")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
    }
}
