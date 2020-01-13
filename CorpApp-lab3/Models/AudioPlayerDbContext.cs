using System.Data.Entity;

namespace CorpApp_lab3.Models
{
    public class AudioPlayerDbContext : DbContext
    {
        public DbSet<MusicTrack> MusicTracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MusicTrackAuthor> MusicTrackAuthors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>().HasMany(c => c.MusicTracks)
                .WithMany(s => s.Playlists)
                .Map(t => t.MapLeftKey("PlaylistId")
                    .MapRightKey("TrackId")
                    .ToTable("MusicTracksPlaylists"));
        }
    }

}