using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using MindServer.Domain.DataContracts;
using MindServer.Services.Interfaces;

namespace MindServer.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountService _accountService;

        public AdminController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Admin
        public ActionResult LogIn()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn([FromBody] AdminLogInRequest adminLogInRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(adminLogInRequest);
            }
            try
            {
                var response = await _accountService.AdminLogin(adminLogInRequest);
                if (response.Success)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                adminLogInRequest.Success = false;
                return View(adminLogInRequest);
            }
            catch (Exception)
            {
                adminLogInRequest.Success = false;
                return View(adminLogInRequest);
            }
        }
    }
}