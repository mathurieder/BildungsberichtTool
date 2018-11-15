using System;

namespace BildungsberichtTemplate
{
    public class Bewertung
    {
        public int Id { get; set; }

        public EnumNote Note { get; set; }

        public EnumKategorie Kategorie { get; set; }

        public EnumSubKategorie SubKategorie { get; set; }

        public string Beschreibung { get; set; }

        public string PdfFieldKey { get; set; }

        public String SubKategorieText
        {
            get
            {
                return this.SubKategorie.ToString().Replace("_", " ");
            }
        }
    }
}
