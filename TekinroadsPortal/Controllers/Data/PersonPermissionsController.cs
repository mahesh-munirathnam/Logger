using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Logger.DAL;

namespace TekinroadsPortal.Controllers.Data
{
    public class PersonPermissionsController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: PersonPermissions
        public async Task<ActionResult> Index()
        {
            var personPermissions = db.PersonPermissions.Include(p => p.Permission).Include(p => p.Person);
            return View(await personPermissions.ToListAsync());
        }

        // GET: PersonPermissions/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPermission personPermission = await db.PersonPermissions.FindAsync(id);
            if (personPermission == null)
            {
                return HttpNotFound();
            }
            return View(personPermission);
        }

        // GET: PersonPermissions/Create
        public ActionResult Create()
        {
            ViewBag.PermissionId = new SelectList(db.Permissions, "PermissionId", "PermissionName");
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name");
            return View();
        }

        // POST: PersonPermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PersonPermissionId,PersonId,PermissionId,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate")] PersonPermission personPermission)
        {
            if (ModelState.IsValid)
            {
                db.PersonPermissions.Add(personPermission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PermissionId = new SelectList(db.Permissions, "PermissionId", "PermissionName", personPermission.PermissionId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name", personPermission.PersonId);
            return View(personPermission);
        }

        // GET: PersonPermissions/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPermission personPermission = await db.PersonPermissions.FindAsync(id);
            if (personPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "PermissionId", "PermissionName", personPermission.PermissionId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name", personPermission.PersonId);
            return View(personPermission);
        }

        // POST: PersonPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PersonPermissionId,PersonId,PermissionId,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate")] PersonPermission personPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personPermission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "PermissionId", "PermissionName", personPermission.PermissionId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "Name", personPermission.PersonId);
            return View(personPermission);
        }

        // GET: PersonPermissions/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPermission personPermission = await db.PersonPermissions.FindAsync(id);
            if (personPermission == null)
            {
                return HttpNotFound();
            }
            return View(personPermission);
        }

        // POST: PersonPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            PersonPermission personPermission = await db.PersonPermissions.FindAsync(id);
            db.PersonPermissions.Remove(personPermission);
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
