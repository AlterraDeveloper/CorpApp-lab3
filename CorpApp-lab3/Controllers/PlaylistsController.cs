using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CorpApp_lab3.Models;

namespace CorpApp_lab3.Controllers
{
    [Authorize]
    public class PlaylistsController : Controller
    {
        private readonly AudioPlayerDbContext _dbContext = new AudioPlayerDbContext();

        public ActionResult Index()
        {
            return View(_dbContext.Playlists.Where(p => p.Owner.FullName == User.Identity.Name).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var _playlist = _dbContext.Playlists.FirstOrDefault(x => x.Name == playlist.Name);

                if (_playlist == null)
                {
                    playlist.UserId = _dbContext.Users.FirstOrDefault(x => x.FullName == User.Identity.Name).Id;

                    _dbContext.Entry(playlist).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Название плейлиста должно быть уникальным");

            }

            return Create();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var playlist = _dbContext.Playlists.Find(id);

            if (playlist != null)
            {
                return View(playlist);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var _playlist = _dbContext.Playlists.FirstOrDefault(x => x.Name == playlist.Name && x.PlaylistId != playlist.PlaylistId);

                if (_playlist == null)
                {
                    playlist.UserId = _dbContext.Users.FirstOrDefault(x => x.FullName == User.Identity.Name).Id;

                    _dbContext.Entry(playlist).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Название плейлиста должно быть уникальным");
            }

            return Edit(playlist.PlaylistId);
        }

        public ActionResult Delete(int id)
        {
            var playlist = _dbContext.Playlists.Find(id);

            if (playlist != null)
            {
                _dbContext.Entry(playlist).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult RemoveTrack(int playlistId, int trackId)
        {
            var playlist = _dbContext.Playlists.Find(playlistId);

            var track = _dbContext.MusicTracks.Find(trackId);

            if (playlist != null && track != null)
            {
                playlist.MusicTracks.Remove(track);
                _dbContext.Entry(playlist).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Edit",new {id = playlistId});
        }
    }
}