using Model;
using ServiceClient.PersonaFisica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class PersonaFisicaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get() 
        {            
            var client = new PersonaFisicaClient();
            var list = client.Get();

            list = list.Select(persona => { 
                persona.CreatedDate = persona.FechaRegistro.ToString("yyyy/MM/dd");
                persona.UpdatedDate = persona.FechaActualizacion.ToString("yyyy/MM/dd");
                persona.BirthDay = persona.FechaNacimiento.ToString("yyyy-MM-dd");                

                return persona;
            }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult GetById(int id)
        {
            var client = new PersonaFisicaClient();
            var list = client.Get(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Post(PersonaFisica personaFisica) 
        {
            var client = new PersonaFisicaClient();
            var response = client.Post(personaFisica);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Put (PersonaFisica personaFisica)
        {
            var client = new PersonaFisicaClient();
            var response = client.Put(personaFisica);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var client = new PersonaFisicaClient();
            var response = client.Delete(id);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}