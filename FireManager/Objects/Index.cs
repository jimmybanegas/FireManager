using System.Collections.Generic;

namespace FireManager.Objects
{
    public class Index
    {
        public string Nombre { get; set; }

        public string Comentario { get; set; }

        public List<Field> Campos { get; set; }

        public void Inicializar()
        {
            Campos = new List<Field>();
        }
    }
}