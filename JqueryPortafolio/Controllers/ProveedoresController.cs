using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JqueryPortafolio.Models;

namespace Tienda.Controllers
{
    public class ProveedoresController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Proveedores
        public ActionResult Index()
        {
            return View(db.Tbl_Proveedor.ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Proveedor tbl_Proveedor = db.Tbl_Proveedor.Find(id);
            if (tbl_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Proveedor);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProveedor,NombreProveedor")] Tbl_Proveedor tbl_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Proveedor.Add(tbl_Proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Proveedor);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Proveedor tbl_Proveedor = db.Tbl_Proveedor.Find(id);
            if (tbl_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Proveedor);
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProveedor,NombreProveedor")] Tbl_Proveedor tbl_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Proveedor);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Proveedor tbl_Proveedor = db.Tbl_Proveedor.Find(id);
            if (tbl_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Proveedor);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Proveedor tbl_Proveedor = db.Tbl_Proveedor.Find(id);
            db.Tbl_Proveedor.Remove(tbl_Proveedor);
            db.SaveChanges();
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
