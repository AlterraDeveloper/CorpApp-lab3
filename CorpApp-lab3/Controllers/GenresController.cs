using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CorpApp_lab3.Models;

namespace CorpApp_lab3.Controllers
{
    [Authorize]
    public class GenresController : Controller
    {
        private readonly AudioPlayerDbContext _dbContext = new AudioPlayerDbContext();

        public ActionResult Index()
        {
            return View(_dbContext.Genres.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                var _genre = _dbContext.Genres.FirstOrDefault(x => x.Name == genre.Name);

                if (_genre == null)
                {
                    _dbContext.Entry(genre).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Название жанра должно быть уникальным");

            }

            return Create();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var genre = _dbContext.Genres.Find(id);

            if (genre != null)
            {
                return View(genre);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                var _genre = _dbContext.Genres.FirstOrDefault(x => x.Name == genre.Name && x.Id != genre.Id);

                if (_genre == null)
                {
                    _dbContext.Entry(genre).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Название жанра должно быть уникальным");
            }

            return Edit(genre.Id);
        }

        public ActionResult Delete(int id)
        {
            var genre = _dbContext.Genres.Find(id);

            if (genre != null)
            {
                _dbContext.Entry(genre).State = EntityState.Deleted;
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