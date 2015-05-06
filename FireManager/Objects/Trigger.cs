using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireManager.EnumTypes;
using FireManager.Models;

namespace FireManager.Objects
{
    public class Trigger
    {
        public string Nombre { get; set; }

        public string Comentario { get; set; }

        public Table Tabla { get; set; }

        public TriggerEvent Evento { get; set; }

        public TriggerType Tipo { get; set; }

        public int Posicion { get; set; }

        public bool Activo { get; set; }

        public string Definicion { get; set; }
    }
}
