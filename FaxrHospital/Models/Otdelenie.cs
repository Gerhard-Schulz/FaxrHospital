using System.ComponentModel.DataAnnotations;

namespace FaxrHospital.Models
{
    public class Otdelenie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
