using System.Collections.Generic;
using FireManager.Models;

namespace FireManager.Objects
{
    public class Table
    {
        public string Nombre { get; set; }

        public string Comentario { get; set; }

        public List<Field> Campos { get; set; }

        public List<Index> Indices { get; set; }

        public List<ForeignKey> Foraneas { get; set; }

    }
}
