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
    public class PacientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(db.Pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacienteID,Nome,CPF,DataNasc")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if ((db.Pacientes.FirstOrDefault(x => x.CPF == paciente.CPF)) == null) { 
                    db.Pacientes.Add(paciente);
                    db.SaveChanges();
                    TempData["Mensagem"] = "Paciente Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }else{
                        TempData["Mensagem"] = "Paciente já Cadastrado!";
                        return View(paciente);
                }
                }
                catch
                {
                    TempData["Mensagem"] = "Erro ao Cadastrar Paciente!";
                    return View(paciente);

                }
            }

            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacienteID,Nome,CPF,DataNasc")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(paciente).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Paciente Editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Mensagem"] = "Erro ao Editar Paciente!";
                    return View();
                }
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Paciente paciente = db.Pacientes.Find(id);
                db.Pacientes.Remove(paciente);
                db.SaveChanges();
                TempData["Mensagem"] = "Paciente Excluido com Sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Erro ao Excluir Paciente!";
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
