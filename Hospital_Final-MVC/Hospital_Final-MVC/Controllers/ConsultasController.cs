using BaseModels;
using Hospital_Final_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Final_MVC.Controllers
{
    public class ConsultasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Consultas
        public ActionResult Index()
        {
            var consultas = db.Consultas.Include(c => c._Medico).Include(c => c._Paciente).Include(c => c._TipoConsulta);
            return View(db.Consultas.ToList());
        }

        //Criar
        public ActionResult Create()
        {
            ViewBag.MedicoID = new SelectList(db.Medicos, "MedicoID", "Nome");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nome");
            ViewBag.TipoConsultaID = new SelectList(db.TipoConsultas, "TipoConsultaID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultaID,PacienteID,MedicoID,TipoConsultaID,DataConsulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if ((db.Consultas.FirstOrDefault(x => x._Medico == consulta._Medico && x._Paciente == consulta._Paciente && x._TipoConsulta == consulta._TipoConsulta && x.DataConsulta == consulta.DataConsulta)) == null)
                    {
                        db.Consultas.Add(consulta);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Consulta Cadastrada com Sucesso!";
                        return RedirectToAction("Index");
                    }else
                    {
                        TempData["Mensagem"] = "Consulta já Cadastrada!";
                        return View(consulta);
                    }
                }
                catch
                {
                    TempData["Mensagem"] = "Erro ao Cadastrar Consulta!";
                    return View(consulta);
                } 
            }
            ViewBag.MedicoID = new SelectList(db.Medicos, "MedicoID", "Nome");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nome");
            ViewBag.TipoConsultaID = new SelectList(db.TipoConsultas, "TipoConsultaID", "Nome");
            return View(consulta);
        }

        //Editar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicoID = new SelectList(db.Medicos, "MedicoID", "Nome");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nome");
            ViewBag.TipoConsultaID = new SelectList(db.TipoConsultas, "TipoConsultaID", "Nome");
            return View(consulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultaID,PacienteID,MedicoID,TipoConsultaID,DataConsulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(consulta).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Consulta Editada com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Mensagem"] = "Erro ao Cadastrar Consulta!";
                    return View(consulta);
                }
            }
            ViewBag.MedicoID = new SelectList(db.Medicos, "MedicoID", "Nome");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "PacienteID", "Nome");
            ViewBag.TipoConsultaID = new SelectList(db.TipoConsultas, "TipoConsultaID", "Nome");
            return View(consulta);
        }

        //Deletar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Consulta consulta = db.Consultas.Find(id);
                db.Consultas.Remove(consulta);
                db.SaveChanges();
                TempData["Mensagem"] = "Consulta Excluida com Sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Erro ao Cadastrar Consulta!";
                return View();
            }
        }
    }
}