using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MindServer.EF;
using MindServer.Utils;
using MindServer.ViewModel;

namespace MindServer.Controllers.Web
{
    public class LoginController : Controller
    {
        private readonly MindServerDbContext _dbContext = new MindServerDbContext();
        //
        // GET: /Login/

        /// <summary>
        ///     Login User View
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityUtil.AuthenticUser(User)) return RedirectToAction("Index", "Home");
            return View();
        }

        /// <summary>
        ///     Login User Post Back
        /// </summary>
        /// <param name="loginModel">User Login Form</param>
        /// <returns>Login View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel loginModel)
        {
            if (SecurityUtil.AuthenticUser(User)) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                var existingUser = _dbContext.Users.FirstOrDefault(user => user.EmailAddress == loginModel.EmailAddress);
                if (existingUser != null)
                {
                    if (SecurityUtil.IsPasswordValid(existingUser, loginModel.Password))
                    {
                        //Password Valid
                        FormsAuthentication.SetAuthCookie(existingUser.Id.ToString(), false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View();
        }

        public ActionResult Signout()
        {
            if (User.Identity.IsAuthenticated) FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}