using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace CorpApp_lab3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }       
        public string HashPassword { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<Playlist> Playlists { get; set; }

        public User()
        {
            Playlists = new List<Playlist>();
        }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}