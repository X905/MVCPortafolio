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
    public class ProductosController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var tbl_Producto = db.Tbl_Producto.Include(t => t.Tbl_Proveedor);
            return View(tbl_Producto.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Producto tbl_Producto = db.Tbl_Producto.Find(id);
            if (tbl_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedor = new SelectList(db.Tbl_Proveedor, "IdProveedor", "NombreProveedor");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,ProductoNombre,ProductoPrecio,ProductoCantidad,ProductoDescripcion,IdProveedor")] Tbl_Producto tbl_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Producto.Add(tbl_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedor = new SelectList(db.Tbl_Proveedor, "IdProveedor", "NombreProveedor", tbl_Producto.IdProveedor);
            return View(tbl_Producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Producto tbl_Producto = db.Tbl_Producto.Find(id);
            if (tbl_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedor = new SelectList(db.Tbl_Proveedor, "IdProveedor", "NombreProveedor", tbl_Producto.IdProveedor);
            return View(tbl_Producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,ProductoNombre,ProductoPrecio,ProductoCantidad,ProductoDescripcion,IdProveedor")] Tbl_Producto tbl_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedor = new SelectList(db.Tbl_Proveedor, "IdProveedor", "NombreProveedor", tbl_Producto.IdProveedor);
            return View(tbl_Producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Producto tbl_Producto = db.Tbl_Producto.Find(id);
            if (tbl_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Producto tbl_Producto = db.Tbl_Producto.Find(id);
            db.Tbl_Producto.Remove(tbl_Producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Venta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Producto tbl_Producto = db.Tbl_Producto.Find(id);
            if (tbl_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedor = new SelectList(db.Tbl_Proveedor, "IdProveedor", "NombreProveedor", tbl_Producto.IdProveedor);
            return View(tbl_Producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Venta([Bind(Include = "IdProducto,ProductoNombre,ProductoPrecio,ProductoCantidad,ProductoDescripcion,IdProveedor")] Tbl_Producto tbl_Producto, int cantidadProducto)
        {
            if (ModelState.IsValid)
            {
                tbl_Producto.ProductoCantidad = tbl_Producto.ProductoCantidad - cantidadProducto;
                db.Entry(tbl_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedor = new SelectList(db.Tbl_Proveedor, "IdProveedor", "NombreProveedor", tbl_Producto.IdProveedor);
            return View(tbl_Producto);
        }
        public ActionResult PrecioVenta(int IdProducto, int cantidadProducto)
        {
            var precioProducto = db.Tbl_Producto.Where(x => x.IdProducto == IdProducto).FirstOrDefault().ProductoPrecio;
            int valor = int.Parse(precioProducto.ToString());

            return Content((valor * cantidadProducto).ToString());
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
