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
    public class TipoConsultasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoConsultas
        public ActionResult Index()
        {

            if (User.IsInRole("admin"))
                           {
                
                           }
            return View(db.TipoConsultas.ToList());
        }

        // GET: TipoConsultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
            if (tipoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoConsultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoConsultaID,Nome,Valor")] TipoConsulta tipoConsulta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if ((db.TipoConsultas.FirstOrDefault(x => x.Nome == tipoConsulta.Nome)) == null) { 
                    db.TipoConsultas.Add(tipoConsulta);
                    db.SaveChanges();
                    TempData["Mensagem"] = "Tipo Consulta Criado com Sucesso!";
                    return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Tipo Consulta já existente!";
                        return View(tipoConsulta);
                    }
                }
                catch
                {
                    TempData["Mensagem"] = "Erro ao Cadastrar Tipo Consulta!";
                    return View(tipoConsulta);
                }
                
            }

            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
            if (tipoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsulta);
        }

        // POST: TipoConsultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoConsultaID,Nome,Valor")] TipoConsulta tipoConsulta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tipoConsulta).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Tipo Consulta Editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Mensagem"] = "Erro ao Editar Tipo Consulta!";
                    return View(tipoConsulta);
                }
            }
            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
            if (tipoConsulta == null)
            {
                return HttpNotFound();
            }
            return View(tipoConsulta);
        }

        // POST: TipoConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TipoConsulta tipoConsulta = db.TipoConsultas.Find(id);
                db.TipoConsultas.Remove(tipoConsulta);
                db.SaveChanges();
                TempData["Mensagem"] = "Tipo Consulta Excluido com Sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Erro ao Excluir Tipo Consulta!";
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
