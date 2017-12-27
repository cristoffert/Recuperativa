using Recuperativa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalesVaca.Controllers
{
    public class HomeController : Controller
    {
        RECUPERATIVAEntities cnx;
        public HomeController()
        {
            cnx = new RECUPERATIVAEntities();
        }
        public ActionResult Formulario()
        {
            return View();
        }
        public ActionResult Guardar(int diio, string nombre, string sexo, string raza, string leche)
        {

            Recuperativa.Models.Vaca vacas = new Recuperativa.Models.Vaca()
            {
                Diio = diio,
                Nombre = nombre,
                Sexo = sexo,
                Raza = raza,
                Leche = leche
            };

            cnx.Vaca.Add(vacas);
            cnx.SaveChanges();

            return View("Listado", ListadoVacas());
        }
        public ActionResult Listado()
        {

            return View("Listado", ListadoVacas());
        }
        public ActionResult Ficha(int diio)
        {
            Vaca vaca = (Vaca)cnx.Vaca.Where(x => x.Diio==diio).First();

            return View("Ficha", vaca);
        }
        private List<Recuperativa.Models.Vaca> ListadoVacas()
        {

            cnx.Database.Connection.Open();
            List<Recuperativa.Models.Vaca> vacas = cnx.Vaca.ToList();

            cnx.Database.Connection.Close();

            return vacas;
        }
    }
}