using FireManager.EnumTypes;
using FireManager.Models;

namespace FireManager.Objects
{
    public class Field
    {
        public string Nombre { get; set; }

        public DataTypes Tipo { get; set; }

        public int Tamano { get; set; }

        public bool NoNulos { get; set; }

        public bool EsLlavePrimaria { get; set; }

        public bool UsaAutoIncremento { get; set; }
    }
}