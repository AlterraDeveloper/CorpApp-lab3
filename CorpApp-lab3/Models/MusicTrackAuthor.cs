using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CorpApp_lab3.Models
{
    public class MusicTrackAuthor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [MaxLength(50, ErrorMessage = "Введите не более 50 симоволов")]
        [Display(Name = "Исполнитель")]
        public string Name { get; set; }

        public ICollection<MusicTrack> MusicTracks { get; set; }

        public MusicTrackAuthor()
        {
            MusicTracks = new List<MusicTrack>();
        }
    }
}