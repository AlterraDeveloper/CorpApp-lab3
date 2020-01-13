using System.ComponentModel.DataAnnotations;

namespace CorpApp_lab3.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [MaxLength(50,ErrorMessage = "Введите не более 50 симоволов")]
        [Display(Name = "Название жанра")]
        public string Name { get; set; }
    }
}