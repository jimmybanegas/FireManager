namespace FireManager.Objects
{
    public class ForeignKey
    {
        public string Nombre { get; set; }

        public Field Campo { get; set; }

        public Table TablaReferida { get; set; }

        public Field CampoReferico { get; set; }
    }
}