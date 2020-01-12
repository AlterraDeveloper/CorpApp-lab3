using System.Data.Entity;
using CorpApp_lab3.Utils;

namespace CorpApp_lab3.Models
{
    public class AudioPlayerDbContext : DbContext
    {
        public DbSet<MusicTrack> MusicTracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MusicTrackAuthor> MusicTrackAuthors { get; set; }
        public DbSet<User> Users { get; set; }
    }

}