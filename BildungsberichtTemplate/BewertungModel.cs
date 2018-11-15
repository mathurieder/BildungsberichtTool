namespace BildungsberichtTemplate
{
    public class BewertungModel
    {
        public Bewertung Bewertung { get; set; }

        public BewertungsBeschreibung SelectedBeschreibung { get; set; }

        //public string Beschreibung { get; set; }

        public bool NoteA { get; set; }

        public bool NoteB { get; set; }

        public bool NoteC { get; set; }

        public bool NoteD { get; set; }

        public EnumNote GetNote()
        {
            if (NoteA) return EnumNote.A;
            if (NoteB) return EnumNote.B;
            if (NoteC) return EnumNote.C;
            if (NoteD) return EnumNote.D;
            return EnumNote.None;
        }
    }
}
