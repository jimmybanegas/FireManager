using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireManager.Objects
{
    public class View
    {
        public string Nombre { get; set; }

        public Table Tabla { get; set; }

        public List<Field> Campos { get; set; }

        public void Inicializar()
        {
            Campos = new List<Field>();
        }
    }
}
