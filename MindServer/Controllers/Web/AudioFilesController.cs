using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using MindServer.Domain.Entities;
using MindServer.EF;

namespace MindServer.Controllers.Web
{
    [Authorize]
    public class AudioFilesController : Controller
    {
        private readonly MindServerDbContext db = new MindServerDbContext();
        // GET: AudioFiles
        public async Task<ActionResult> Index()
        {
            return View(await db.AudioFiles.ToListAsync());
        }

        // GET: AudioFiles/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var audioFile = await db.AudioFiles.FindAsync(id);
            if (audioFile == null)
            {
                return HttpNotFound();
            }
            return View(audioFile);
        }

        // GET: AudioFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AudioFiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(
                Include =
                    "Id,FileName,FileUrl,Title,Duration,Description,ThumbnailUrl,ImageUrl,BaseColour,MediaType,CreatedDateTime"
                )] AudioFile audioFile)
        {
            if (ModelState.IsValid)
            {
                db.AudioFiles.Add(audioFile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(audioFile);
        }

        // GET: AudioFiles/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var audioFile = await db.AudioFiles.FindAsync(id);
            if (audioFile == null)
            {
                return HttpNotFound();
            }
            return View(audioFile);
        }

        // POST: AudioFiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(
                Include =
                    "Id,FileName,FileUrl,Title,Duration,Description,ThumbnailUrl,ImageUrl,BaseColour,MediaType,CreatedDateTime"
                )] AudioFile audioFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audioFile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(audioFile);
        }

        // GET: AudioFiles/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var audioFile = await db.AudioFiles.FindAsync(id);
            if (audioFile == null)
            {
                return HttpNotFound();
            }
            return View(audioFile);
        }

        // POST: AudioFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var audioFile = await db.AudioFiles.FindAsync(id);
            db.AudioFiles.Remove(audioFile);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}