using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonaFisica
    {
        [DataMember]
        public int IdPersonaFisica { get; set; }
        
        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public DateTime FechaActualizacion { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string ApellidoPaterno { get; set; }

        [DataMember]
        public string ApellidoMaterno { get; set; }

        [DataMember]
        public string RFC { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public int UsuarioAgrega { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        #region ViewData

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }

        public string BirthDay { get; set; }

        #endregion
    }
}
