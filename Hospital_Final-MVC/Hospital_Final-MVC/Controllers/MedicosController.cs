using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseModels;
using Hospital_Final_MVC.Models;

namespace Hospital_Final_MVC.Controllers
{
    public class MedicosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicos
        public ActionResult Index()
        {

            if (User.IsInRole("admin"))
                           {

                           }
            return View(db.Medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicoID,Nome,CRM,DataNasc")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if((db.Medicos.FirstOrDefault(x => x.CRM == medico.CRM))== null)
                    {
                        db.Medicos.Add(medico);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Medico Criado com Sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Medico já existente!";
                        return View(medico);
                    }
                }
                catch
                {
                    TempData["Mensagem"] = "Houve um Erro!";
                    return View(medico);
                }
                
            }

            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicoID,Nome,CRM,DataNasc")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(medico).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Medico Editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Mensagem"] = "Erro ao Editar Medico!";
                    return View(medico);
                }
                
            }
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Medico medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
                db.SaveChanges();
                TempData["Mensagem"] = "Medico Excluido com Sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Erro ao Excluir Medico!";
                return View();
            }   
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
