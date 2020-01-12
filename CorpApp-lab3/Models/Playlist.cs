using System.Collections.Generic;

namespace CorpApp_lab3.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<MusicTrack> MusicTracks { get; set; }

        public Playlist()
        {
            MusicTracks = new List<MusicTrack>();
        }
    }
}