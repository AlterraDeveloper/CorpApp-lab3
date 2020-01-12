using System.Collections.Generic;

namespace CorpApp_lab3.Models
{
    public class MusicTrackAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MusicTrack> MusicTracks { get; set; }

        public MusicTrackAuthor()
        {
            MusicTracks = new List<MusicTrack>();
        }
    }
}