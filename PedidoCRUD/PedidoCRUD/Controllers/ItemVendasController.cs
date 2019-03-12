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
    public class ItemVendasController : Controller
    {
        private PAPEntities db = new PAPEntities();

        // GET: ItemVendas
        public ActionResult Index(int? id)
        {
            if(id != null)
            {
                var itemVenda = db.ItemVenda.Include(i => i.PedidoVenda).Where(i => i.seqPedVenda == id);
                return View(itemVenda.ToList());
            }
            else
            {
                var itemVenda = db.ItemVenda.Include(i => i.PedidoVenda);
                return View(itemVenda.ToList());
            }
        }

        // GET: ItemVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItemVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // GET: ItemVendas/Create
        public ActionResult Create()
        {
            ViewBag.seqPedVenda = new SelectList(db.PedidoVenda, "seqPedVenda", "seqPedVenda");
            return View();
        }

        // POST: ItemVendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "seqPedVendaItem,seqPedVenda,quantidade,embalagem,vlrItem")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.ItemVenda.Add(itemVenda);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = itemVenda.seqPedVenda });
            }

            ViewBag.seqPedVenda = new SelectList(db.PedidoVenda, "seqPedVenda", "seqPedVenda", itemVenda.seqPedVenda);
            return View(itemVenda);
        }

        // GET: ItemVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItemVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.seqPedVenda = new SelectList(db.PedidoVenda, "seqPedVenda", "seqPedVenda", itemVenda.seqPedVenda);
            return View(itemVenda);
        }

        // POST: ItemVendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "seqPedVendaItem,seqPedVenda,quantidade,embalagem,vlrItem")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.seqPedVenda = new SelectList(db.PedidoVenda, "seqPedVenda", "seqPedVenda", itemVenda.seqPedVenda);
            return View(itemVenda);
        }

        // GET: ItemVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItemVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // POST: ItemVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemVenda itemVenda = db.ItemVenda.Find(id);
            db.ItemVenda.Remove(itemVenda);
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
