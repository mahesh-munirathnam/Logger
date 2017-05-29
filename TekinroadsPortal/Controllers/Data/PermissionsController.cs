using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Logger.DAL;

namespace TekinroadsPortal.Controllers.Data
{
    public class PermissionsController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Permissions
        public async Task<ActionResult> Index()
        {
            return View(await db.Permissions.ToListAsync());
        }

        // GET: Permissions/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = await db.Permissions.FindAsync(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // GET: Permissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PermissionId,PermissionName,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Permissions.Add(permission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(permission);
        }

        // GET: Permissions/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = await db.Permissions.FindAsync(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PermissionId,PermissionName,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        // GET: Permissions/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = await db.Permissions.FindAsync(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Permission permission = await db.Permissions.FindAsync(id);
            db.Permissions.Remove(permission);
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
