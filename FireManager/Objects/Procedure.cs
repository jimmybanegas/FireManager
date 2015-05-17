using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireManager.Objects
{
    public class Procedure
    {
        public string Nombre { get; set; }

        public string Comentario { get; set; }

        public string Definicion { get; set; }

        public List<ProcParameter> Parametros { get; set; }

        public void Inicializar()
        {
            Parametros = new List<ProcParameter>();
        }
    }
}
