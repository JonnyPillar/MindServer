using System.Web.Mvc;
using MindServer.Services.Interfaces;

namespace MindServer.Controllers.Web
{
    public class MediaWebController : Controller
    {
        private readonly IMediaService _mediaService;

        public MediaWebController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        // GET: MediaWeb
        public ActionResult Index()
        {
            var mediaItems = _mediaService.GetAllMediaApiResponse();
            return View(mediaItems);
        }

        // GET: MediaWeb/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MediaWeb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaWeb/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MediaWeb/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MediaWeb/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MediaWeb/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MediaWeb/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}