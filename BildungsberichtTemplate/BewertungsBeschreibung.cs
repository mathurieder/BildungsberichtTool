namespace BildungsberichtTemplate
{
    public class BewertungsBeschreibung
    {
        public int Id { get; set; }

        public EnumNote Note { get; set; }

        public EnumKategorie Kategorie { get; set; }

        public EnumSubKategorie SubKategorie { get; set; }

        public string Beschreibung { get; set; }

        public override string ToString()
        {
            return Beschreibung;
        }
    }
}
