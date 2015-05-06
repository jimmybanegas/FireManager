using FireManager.EnumTypes;
using FireManager.Models;

namespace FireManager.Objects
{
    public class FunctionParameter
    {
        public MechanismFunctionParameter Mecanismo { get; set; }

        public DataTypes Tipo { get; set; }

        public bool IsReturn { get; set; }
    }
}