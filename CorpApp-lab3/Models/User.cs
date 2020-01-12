using System.Collections.Generic;

namespace CorpApp_lab3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }       
        public string HashPassword { get; set; }
        //public bool IsAdmin { get; set; }

        public ICollection<Playlist> Playlists { get; set; }

        public User()
        {
            Playlists = new List<Playlist>();
        }
    }
}