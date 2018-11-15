using System.Collections.Generic;

namespace BildungsberichtTemplate
{
    public class Lernende
    {
        public string Name
        {
            get;
            set;
        }

        public string Vorname
        {
            get;
            set;
        }

        public string Lehrbetrieb
        {
            get;
            set;
        }

        public string Coach
        {
            get;
            set;
        }

        public EnumGender Gender
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{Name} {Vorname}, {Lehrbetrieb}";
        }

        public static List<Lernende> GetLernende()
        {
            return new List<Lernende> {
                new Lernende { Name = "Pagani", Vorname = "Alessia", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Female },
                new Lernende { Name = "Durovic", Vorname = "Alida", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Female },
                new Lernende { Name = "Wagner", Vorname = "Anaëlle", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Female },
                new Lernende { Name = "Gojkovic", Vorname = "Anastasija", Lehrbetrieb = "Credit Suisse", Coach = "Mathias", Gender = EnumGender.Female },
                new Lernende { Name = "Calamia", Vorname = "Claudio", Lehrbetrieb = "SIX", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Karsiljan", Vorname = "Daniel", Lehrbetrieb = "Flughafen Zürich", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Nguyen", Vorname = "Daniel", Lehrbetrieb = "Leonteq Securities", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Sandholzer", Vorname = "Diego", Lehrbetrieb = "SIX", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Bajrektarevic", Vorname = "Enis", Lehrbetrieb = "Sunrise Communications", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Dougan", Vorname = "Finley", Lehrbetrieb = "Credit Suisse", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Riahi", Vorname = "Ismail", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Male },
                new Lernende { Name = "Dahinden", Vorname = "Jeffry", Lehrbetrieb = "Raiffeisen Schweiz", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Staub", Vorname = "Jerome", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Male },
                new Lernende { Name = "Gubler", Vorname = "Laurin", Lehrbetrieb = "tpc switzerland", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Eberhard", Vorname = "Lorenz", Lehrbetrieb = "Allianz Suisse", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Stefanelli", Vorname = "Mathis", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Male },
                new Lernende { Name = "Killenberger", Vorname = "Niklas", Lehrbetrieb = "Credit Suisse", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Koch", Vorname = "Noah", Lehrbetrieb = "Tamedia", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Zenullahu", Vorname = "Skender", Lehrbetrieb = "SWITCH", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Im", Vorname = "Sophie", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Female },
                new Lernende { Name = "Mantegazzi", Vorname = "Tobias", Lehrbetrieb = "Credit Suisse", Coach = "Marco", Gender = EnumGender.Male },
                new Lernende { Name = "Besson", Vorname = "Yanic", Lehrbetrieb = "Sunrise Communications", Coach = "Mathias", Gender = EnumGender.Male },
                new Lernende { Name = "Sigg", Vorname = "Levin", Lehrbetrieb = "SAP Schweiz", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Vejseli", Vorname = "Albin", Lehrbetrieb = "Kanton Zürich", Coach = "Alexandra", Gender = EnumGender.Male },
                new Lernende { Name = "Fröhlich", Vorname = "Andrin", Lehrbetrieb = "skyguide", Coach = "Alexandra", Gender = EnumGender.Male },
                new Lernende { Name = "Krebs", Vorname = "Armas", Lehrbetrieb = "SRG SSR", Coach = "Alexandra", Gender = EnumGender.Male },
                new Lernende { Name = "Stutz", Vorname = "Benjamin", Lehrbetrieb = "ICT Berufsbildungscenter", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Muharemi", Vorname = "Burim", Lehrbetrieb = "Credit Suisse", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Rivera Allegro", Vorname = "David", Lehrbetrieb = "Kanton Zürich", Coach = "Alexandra", Gender = EnumGender.Male },
                new Lernende { Name = "Kryeziu", Vorname = "Dennis", Lehrbetrieb = "Allianz Suisse", Coach = "Alexandra", Gender = EnumGender.Male },
                new Lernende { Name = "Rechsteiner", Vorname = "Felix", Lehrbetrieb = "RUAG Schweiz", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Milosavljevic", Vorname = "Filip", Lehrbetrieb = "UPC Schweiz", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Muratoska", Vorname = "Florentina", Lehrbetrieb = "Credit Suisse", Coach = "Martin", Gender = EnumGender.Female },
                new Lernende { Name = "Jeyaseelan", Vorname = "Jeroon", Lehrbetrieb = "OBT", Coach = "Alexandra", Gender = EnumGender.Male },
                new Lernende { Name = "Wachter", Vorname = "Jonas", Lehrbetrieb = "UPC Schweiz", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Vejseli", Vorname = "Leart", Lehrbetrieb = "Credit Suisse", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Bajrami", Vorname = "Merve", Lehrbetrieb = "Kanton Zürich", Coach = "Alexandra", Gender = EnumGender.Female },
                new Lernende { Name = "Locherer", Vorname = "Michael", Lehrbetrieb = "Flughafen Zürich", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Ravi", Vorname = "Neushiga", Lehrbetrieb = "Credit Suisse", Coach = "Martin", Gender = EnumGender.Female },
                new Lernende { Name = "Normani", Vorname = "Sergio", Lehrbetrieb = "Credit Suisse", Coach = "Martin", Gender = EnumGender.Male },
                new Lernende { Name = "Xu", Vorname = "Xing", Lehrbetrieb = "Huawei Technologies Switzerland", Coach = "Alexandra", Gender = EnumGender.Male },
                new Lernende { Name = "Gorgoni", Vorname = "Yang", Lehrbetrieb = "Raiffeisen Schweiz", Coach = "Martin", Gender = EnumGender.Female },
                new Lernende { Name = "Lou Zhen Peng", Lehrbetrieb = "Huawei Technologies Switzerland", Coach = "Alexandra", Gender = EnumGender.Male }};
        }
    }
}