using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetHomeDesign.Models;
using System.IO;

namespace BudgetHomeDesign.Controllers
{
    public class PlansController : Controller
    {
        private DbModel db = new DbModel();

        public async Task<ActionResult> Index()
        {
            return View(await db.Plans.ToListAsync());
        }

        // GET: Plans/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = await db.Plans.FindAsync(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Price,Title,Description,Size,Steps,People,Floors")] Plan plan, HttpPostedFileBase PictureUrl)
        {
            string customUid = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
               int rndnum = rnd.Next();

                if (PictureUrl != null && PictureUrl.ContentLength > 0)
                {
                    var getpath = Path.GetFileName(PictureUrl.FileName);
                    var fileName = $"{rndnum}_{getpath}";
                    var path = Path.Combine(Server.MapPath("~/Content/images/Uploads"), fileName);
                    PictureUrl.SaveAs(path);
                    plan.PictureUrl = fileName;
                }

                plan.Id = customUid;
                db.Plans.Add(plan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(plan);
        }

        // GET: Plans/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = await db.Plans.FindAsync(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Price,Title,Description,Size,Steps,People,Floors,PictureUrl")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: Plans/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = await db.Plans.FindAsync(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Plan plan = await db.Plans.FindAsync(id);
            db.Plans.Remove(plan);
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
