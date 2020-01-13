using CorpApp_lab3.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using CorpApp_lab3.ViewModels;

namespace CorpApp_lab3.Controllers
{
    [Authorize]
    public class MusicTracksController : Controller
    {
        private readonly AudioPlayerDbContext _dbContext = new AudioPlayerDbContext();

        public ActionResult Index()
        {
            return View(_dbContext.MusicTracks.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList authors = new SelectList(_dbContext.MusicTrackAuthors,"TrackId","Name");
            SelectList genres = new SelectList(_dbContext.Genres,"TrackId","Name");
            ViewBag.Authors = authors;
            ViewBag.Genres = genres;
            return View();
        }

        [HttpPost]
        public ActionResult Create(MusicTrack musicTrack)
        {
            _dbContext.MusicTracks.Add(musicTrack);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var track = _dbContext.MusicTracks.Find(id);

            if (track != null)
            {
                SelectList authors = new SelectList(_dbContext.MusicTrackAuthors, "Id", "Name");
                SelectList genres = new SelectList(_dbContext.Genres, "Id", "Name");
                ViewBag.Authors = authors;
                ViewBag.Genres = genres;
                return View(track);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(MusicTrack musicTrack)
        {
            _dbContext.Entry(musicTrack).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var track = _dbContext.MusicTracks.Find(id);
            if (track != null)
            {
                _dbContext.Entry(track).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddToPlaylist(int id)
        {
            var userId = _dbContext.Users.FirstOrDefault(x => x.FullName == User.Identity.Name).Id;
            ViewBag.Playlists = new SelectList(_dbContext.Playlists.Where(p => p.UserId == userId), "PlaylistId", "Name"); 
            return View(new MusicTrackPlaylistViewModel
            {
                TrackId = id
            });
        }

        [HttpPost]
        public ActionResult AddToPlaylist(MusicTrackPlaylistViewModel viewModel)
        {
            var playlist = _dbContext.Playlists.Find(viewModel.PlaylistId);
            var track = _dbContext.MusicTracks.Find(viewModel.TrackId);

            track.Playlists.Add(playlist);

            _dbContext.Entry(track).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}