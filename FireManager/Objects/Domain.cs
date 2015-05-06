using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireManager.EnumTypes;
using FireManager.Models;

namespace FireManager.Objects
{
    public class Domain
    {
        public string Nombre { get; set; }

        public string Comentario { get; set; }

        public DataTypes Tipo { get; set; }

        public int Tamano { get; set; }

        public bool NoNulos { get; set; }
    }
}
