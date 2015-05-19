using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireManager.Objects
{
    public class MyView
    {
        public string Nombre { get; set; }

        public List<string> Campos { get; set; }

        public void Inicializar()
        {
            Campos = new List<string>();
        }
    }
}
