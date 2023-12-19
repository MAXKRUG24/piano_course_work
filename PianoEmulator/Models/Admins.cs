using System.ComponentModel.DataAnnotations;

namespace PianoEmulator.Models
{
    public class admins
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [StringLength(30)]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [StringLength(30)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}