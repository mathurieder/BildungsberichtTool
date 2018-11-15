// BildungsberichtTemplate.Model.BildungsberichtDataSource
using System.Collections.Generic;

namespace BildungsberichtTemplate
{
    public static class BildungsberichtDataSource
    {
        public static List<BewertungModel> GetBildungsberichtData()
        {
            return new List<BewertungModel>
        {
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Fachkompetenz,
                    SubKategorie = EnumSubKategorie.Ausbildungsstand,
                    PdfFieldKey = "1_1"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Fachkompetenz,
                    SubKategorie = EnumSubKategorie.Arbeitsqualität,
                    PdfFieldKey = "1_2"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Fachkompetenz,
                    SubKategorie = EnumSubKategorie.Arbeitsmenge_und_Tempo,
                    PdfFieldKey = "1_3"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Fachkompetenz,
                    SubKategorie = EnumSubKategorie.Umsetzung_der_Berufskenntnisse,
                    PdfFieldKey = "1_4"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Methodenkompetenz,
                    SubKategorie = EnumSubKategorie.Arbeitstechnik,
                    PdfFieldKey = "2_1"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Methodenkompetenz,
                    SubKategorie = EnumSubKategorie.Vernetztes_Denken_und_Handeln,
                    PdfFieldKey = "2_2"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Methodenkompetenz,
                    SubKategorie = EnumSubKategorie.Umgang_mit_Mitteln_und_Einrichtungen,
                    PdfFieldKey = "2_3"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Methodenkompetenz,
                    SubKategorie = EnumSubKategorie.Lernstrategie,
                    PdfFieldKey = "2_4"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Sozialkompetenz,
                    SubKategorie = EnumSubKategorie.Teamfähigkeit__Konfliktfähigkeit,
                    PdfFieldKey = "3_1"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Sozialkompetenz,
                    SubKategorie = EnumSubKategorie.Zusammenarbeit,
                    PdfFieldKey = "3_2"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Sozialkompetenz,
                    SubKategorie = EnumSubKategorie.Information_und_Kommunikation,
                    PdfFieldKey = "3_3"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Selbstkompetenz,
                    SubKategorie = EnumSubKategorie.Selbständigkeit__eigenverantwortliches_Handeln,
                    PdfFieldKey = "4_1"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Selbstkompetenz,
                    SubKategorie = EnumSubKategorie.Zuverlässigkeit__Belastbarkeit,
                    PdfFieldKey = "4_2"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Selbstkompetenz,
                    SubKategorie = EnumSubKategorie.Umgangsformen,
                    PdfFieldKey = "4_3"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Selbstkompetenz,
                    SubKategorie = EnumSubKategorie.Motivation,
                    PdfFieldKey = "4_4"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Lerndokumentation,
                    SubKategorie = EnumSubKategorie.Inhalt,
                    PdfFieldKey = "5_1"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Lerndokumentation,
                    SubKategorie = EnumSubKategorie.Darstellung,
                    PdfFieldKey = "5_2"
                }
            },
            new BewertungModel
            {
                Bewertung = new Bewertung
                {
                    Kategorie = EnumKategorie.Lerndokumentation,
                    SubKategorie = EnumSubKategorie.Termineinhaltung,
                    PdfFieldKey = "5_3"
                }
            }
        };
        }
    }

}
