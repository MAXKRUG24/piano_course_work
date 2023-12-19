using System.ComponentModel.DataAnnotations;

namespace PianoEmulator.Models
{
    class recorded
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [StringLength(150)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [Display(Name = "Композиция")]
        public string Composition { get; set; }
    }
}