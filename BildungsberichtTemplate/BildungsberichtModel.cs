namespace BildungsberichtTemplate
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class BildungsberichtModel
    {
        public int Id { get; set; }

        public List<BewertungModel> BewertungenModels { get; set; }

        public ObservableCollection<BewertungsBeschreibung> BewertungenBeschreibungenModels { get; set; }

        public Lernende Lernende { get; set; }

        public Semester Semester { get; set; }

        public string Von { get; set; }

        public string Bis { get; set; }

        public BildungsberichtModel()
        {
            BewertungenModels = BildungsberichtDataSource.GetBildungsberichtData();
        }
    }
}
