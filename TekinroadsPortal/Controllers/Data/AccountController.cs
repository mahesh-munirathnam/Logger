using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Logger.DAL;

namespace TekinroadsPortal.Controllers.Data
{
    public class AccountController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Account
        public async Task<ActionResult> Index()
        {
            return View(await db.People.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PersonId,Name,Designation,Password,Is_Active,Email,DateCreated,DateModified,CreatedBy,ModifiedBy")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Account/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PersonId,Name,Designation,Password,Is_Active,Email,DateCreated,DateModified,CreatedBy,ModifiedBy")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Account/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Person person = await db.People.FindAsync(id);
            db.People.Remove(person);
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
