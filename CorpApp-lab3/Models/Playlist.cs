using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CorpApp_lab3.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [MaxLength(50, ErrorMessage = "Введите не более 50 симоволов")]
        [Display(Name = "Название плейлиста")]
        public string Name { get; set; }

        public int UserId { get; set; }
        
        public virtual User Owner { get; set; }

        [Display(Name = "Композиции в плейлисте")]
        public virtual ICollection<MusicTrack> MusicTracks { get; set; }

        public Playlist()
        {
            MusicTracks = new List<MusicTrack>();
        }
    }
}