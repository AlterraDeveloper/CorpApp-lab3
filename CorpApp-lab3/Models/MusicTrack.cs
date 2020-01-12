﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorpApp_lab3.Models
{
    public class MusicTrack
    {
        public int Id { get; set; }
        [DisplayName("Композиция")]
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        [DisplayName("Исполнитель")]
        public virtual MusicTrackAuthor Author { get; set; }
        [DisplayName("Жанр")]
        public virtual Genre Genre { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }

        public MusicTrack()
        {
            Playlists = new List<Playlist>();
        }
    }
}