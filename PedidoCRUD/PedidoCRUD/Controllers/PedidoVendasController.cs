using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoCRUD.Models;

namespace MvcMovie.Controllers
{
    public class PedidoVendasController : Controller
    {
        private PAPEntities db = new PAPEntities();

        // GET: PedidoVendas
        public ActionResult Index()
        {
            return View(db.PedidoVenda.ToList());
        }

        // GET: PedidoVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVenda pedidoVenda = db.PedidoVenda.Find(id);
            if (pedidoVenda == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVenda);
        }

        // GET: PedidoVendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoVendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "seqPedVenda,nroEmpresa,seqPessoa,dtaPedido")] PedidoVenda pedidoVenda)
        {
            if (ModelState.IsValid)
            {
                db.PedidoVenda.Add(pedidoVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedidoVenda);
        }

        // GET: PedidoVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVenda pedidoVenda = db.PedidoVenda.Find(id);
            if (pedidoVenda == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVenda);
        }

        // POST: PedidoVendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "seqPedVenda,nroEmpresa,seqPessoa,dtaPedido")] PedidoVenda pedidoVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedidoVenda);
        }

        // GET: PedidoVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVenda pedidoVenda = db.PedidoVenda.Find(id);
            if (pedidoVenda == null)
            {
                return HttpNotFound();
            }
            return View(pedidoVenda);
        }

        // POST: PedidoVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoVenda pedidoVenda = db.PedidoVenda.Find(id);
            db.PedidoVenda.Remove(pedidoVenda);
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

        public ActionResult ItemVendas(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoVenda pedidoVenda = db.PedidoVenda.Find(id);
            if (pedidoVenda == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "ItemVendas", id);
        }
    }
}
