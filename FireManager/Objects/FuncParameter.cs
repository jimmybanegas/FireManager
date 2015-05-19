using FireManager.EnumTypes;
using FireManager.Models;

namespace FireManager.Objects
{
    public class FuncParameter
    {
        public MechanismFunctionParameter Mecanismo { get; set; }

        public DataTypes Tipo { get; set; }

        public int Tamano { get; set; }

        public bool IsReturn { get; set; }
    }
}