using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializacion.Models
{

    [Serializable]
    public class Persona
    {
        public string nombre { get; set; }
        public string identidad { get; set; }
        public DateTime fechaNacimiento { get; set; }


        public override string ToString()
        {
            return $" {nombre} ";
        }
    }
}
