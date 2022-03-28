using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST_DEV_API_DADV_26032022.DataAccess;
using TEST_DEV_API_DADV_26032022.Models;

namespace TEST_DEV_API_DADV_26032022.Controllers
{
    public class PersonaFisicaController : ApiController
    {
        // GET: api/PersonaFisica
        public IEnumerable<PersonaFisica> Get()
        {
            var persona = new dbPersonaFisica();
            var list = persona.Get();
            return list;
        }

        // GET: api/PersonaFisica/5
        public PersonaFisica Get(int id)
        {
            var persona = new dbPersonaFisica();
            var response = persona.GetById(id);

            return response;
        }

        // POST: api/PersonaFisica
        public bool Post([FromBody]PersonaFisica personaFisica)
        {
            var persona = new dbPersonaFisica();
            var response = persona.Create(personaFisica);

            return response;
        }

        // PUT: api/PersonaFisica/5
        public bool Put([FromBody]PersonaFisica personaFisica)
        {
            var persona = new dbPersonaFisica();
            var response = persona.Edit(personaFisica);

            return response;
        }

        // DELETE: api/PersonaFisica/5
        public bool Delete([FromBody]int id)
        {
            var persona = new dbPersonaFisica();
            var response = persona.Delete(id);

            return response;
        }
    }
}
