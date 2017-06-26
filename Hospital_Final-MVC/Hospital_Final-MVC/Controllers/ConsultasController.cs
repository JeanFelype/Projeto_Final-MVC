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
                return View(db.Consultas.ToList());
            }

            //Criar
            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "ConsultaID,paciente(Nome),medico(Nome),tipoConsulta(Nome),tipoConsulta(Valor),DataConsulta")] Consulta consulta)
            {
                if (ModelState.IsValid)
                {
                    db.Consultas.Add(consulta);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

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
                return View(consulta);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "ConsultaID,paciente(Nome),medico(Nome),tipoConsulta(Nome),tipoConsulta(Valor),DataConsulta")] Consulta consulta)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(consulta).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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
                Consulta consulta = db.Consultas.Find(id);
                db.Consultas.Remove(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }