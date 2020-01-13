using CorpApp_lab3.Models;
using CorpApp_lab3.Utils;
using CorpApp_lab3.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace CorpApp_lab3.Controllers
{
    public class AccountController : Controller
    {
        private readonly AudioPlayerDbContext _dbContext = new AudioPlayerDbContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var pswdHash = AuthUtil.GetPasswordHash(loginViewModel.Password);
                var user = _dbContext.Users.FirstOrDefault(u => u.Login == loginViewModel.Login && u.HashPassword == pswdHash);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.FullName, true);
                    return RedirectToAction("Index", "MusicTracks");
                }

                ModelState.AddModelError("", "User is not exists");

            }

            return View(loginViewModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.FullName == model.Name && u.Login == model.Login);
                if (user == null)
                {
                    var pswdHash = AuthUtil.GetPasswordHash(model.Password);

                    _dbContext.Users.Add(new User
                    {
                        Login = model.Login,
                        FullName = model.Name,
                        HashPassword = pswdHash
                    });
                    _dbContext.SaveChanges();

                    user = _dbContext.Users.FirstOrDefault(u => u.FullName == model.Name && u.HashPassword == pswdHash);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "MusicTracks");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(model);
    }

    public ActionResult LogOff()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login");
    }

    protected override void Dispose(bool disposing)
    {
        _dbContext.Dispose();
        base.Dispose(disposing);
    }
}
}