using FireManager.EnumTypes;
using FireManager.Models;

namespace FireManager.Objects
{
    public class ProcedureParameter
    {
        public string Nombre { get; set; }
        
        public ScopeProcedureParameter Scope { get; set; }

        public DataTypes Tipo { get; set; }

    }
}