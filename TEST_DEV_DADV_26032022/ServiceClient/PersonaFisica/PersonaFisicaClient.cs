using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient.PersonaFisica
{
    public class PersonaFisicaClient
    {
        private readonly Client _client;

        public PersonaFisicaClient() 
        {
            string _route = ConfigurationManager.AppSettings.Get("PERSONA_FISICA");
            _client = new Client(_route);
        }

        public List<Model.PersonaFisica> Get() 
        {
            var result = _client.Get<List<Model.PersonaFisica>>();
            return result;
        }

        public Model.PersonaFisica Get(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "id", id }                
            };

            var result = _client.Get<Model.PersonaFisica>(parameters);
            return result;
        }

        public bool Post(Model.PersonaFisica personaFisica)
        {
            var result = _client.GeneralReques<bool>(personaFisica, "POST");
            return result;
        }

        public bool Put(Model.PersonaFisica personaFisica)
        {
            var result = _client.GeneralReques<bool>(personaFisica, "PUT");
            return result;
        }

        public bool Delete(int id)
        {
            var result = _client.GeneralReques<bool>(id, "DELETE");
            return result;
        }
    }
}
