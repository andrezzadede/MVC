using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWEB.Models;

namespace MUSICMVC.Controllers
{
    public class RanksController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Ranks
        public ActionResult Index()
        {
            var ranks = db.ranks.Include(r => r.apresentacao).Include(r => r.artista);
            return View(ranks.ToList());
        }

        // GET: Ranks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank rank = db.ranks.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // GET: Ranks/Create
        public ActionResult Create()
        {
            ViewBag.eventoId = new SelectList(db.eventos, "id", "tema");
            ViewBag.artistaId = new SelectList(db.artistas, "id", "nome");
            return View();
        }

        // POST: Ranks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,eventoId,artistaId,pontos")] Rank rank)
        {
            if (ModelState.IsValid)
            {
                db.ranks.Add(rank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.eventoId = new SelectList(db.eventos, "id", "tema", rank.eventoId);
            ViewBag.artistaId = new SelectList(db.artistas, "id", "nome", rank.artistaId);
            return View(rank);
        }

        // GET: Ranks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank rank = db.ranks.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            ViewBag.eventoId = new SelectList(db.eventos, "id", "tema", rank.eventoId);
            ViewBag.artistaId = new SelectList(db.artistas, "id", "nome", rank.artistaId);
            return View(rank);
        }

        // POST: Ranks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,eventoId,artistaId,pontos")] Rank rank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.eventoId = new SelectList(db.eventos, "id", "tema", rank.eventoId);
            ViewBag.artistaId = new SelectList(db.artistas, "id", "nome", rank.artistaId);
            return View(rank);
        }

        // GET: Ranks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank rank = db.ranks.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // POST: Ranks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rank rank = db.ranks.Find(id);
            db.ranks.Remove(rank);
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
