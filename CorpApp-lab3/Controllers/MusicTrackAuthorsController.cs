using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CorpApp_lab3.Models;

namespace CorpApp_lab3.Controllers
{
    [Authorize]
    public class MusicTrackAuthorsController : Controller
    {
        private readonly AudioPlayerDbContext _dbContext = new AudioPlayerDbContext();

        public ActionResult Index()
        {
            return View(_dbContext.MusicTrackAuthors.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MusicTrackAuthor author)
        {
            if (ModelState.IsValid)
            {
                var _author = _dbContext.MusicTrackAuthors.FirstOrDefault(x => x.Name == author.Name);

                if (_author == null)
                {
                    _dbContext.Entry(author).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Имя исполнителя должно быть уникальным");

            }

            return Create();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var author = _dbContext.MusicTrackAuthors.Find(id);

            if (author != null)
            {
                return View(author);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(MusicTrackAuthor author)
        {
            if (ModelState.IsValid)
            {
                var _author = _dbContext.MusicTrackAuthors.FirstOrDefault(x => x.Name == author.Name && x.Id != author.Id);

                if (_author == null)
                {
                    _dbContext.Entry(author).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Имя исполнителя должно быть уникальным");
            }

            return Edit(author.Id);
        }

        public ActionResult Delete(int id)
        {
            var author = _dbContext.MusicTrackAuthors.Find(id);

            if (author != null)
            {
                _dbContext.Entry(author).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}