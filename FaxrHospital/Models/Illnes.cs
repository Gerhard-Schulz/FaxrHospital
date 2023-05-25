using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FaxrHospital.Models
{
    public class Illnes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }
    }
}
