using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace BildungsberichtTemplate
{
    public class BewertungsBeschreibungLiteDb
    {
        private const string Database = "BewertungsBeschreibung1.0.db";

        private const string EntityName = "BewertungsBeschreibung";

        public BewertungsBeschreibungLiteDb()
        {
            //UpdateOnce();
        }

        public void UpdateOnce()
        {
            using (LiteDatabase db = new LiteDatabase("BewertungsBeschreibung1.0.db", null))
            {
                var list = db.GetCollection<BewertungsBeschreibung>("BewertungsBeschreibung").FindAll();
                foreach (var item in list)
                {
                    item.Beschreibung = TextEscaping.setKeywords(item.Beschreibung, null);
                    db.GetCollection<BewertungsBeschreibung>("BewertungsBeschreibung").Update(item);
                }
            }
        }

        public int InsertBewertungsBeschreibung(BewertungsBeschreibung bewertungsBeschreibung, string vorname)
        {
            using (LiteDatabase db = new LiteDatabase("BewertungsBeschreibung1.0.db", null))
            {
                bewertungsBeschreibung.Beschreibung = TextEscaping.setKeywords(bewertungsBeschreibung.Beschreibung, vorname);

                return db.GetCollection<BewertungsBeschreibung>("BewertungsBeschreibung").Insert(bewertungsBeschreibung);
            }
        }

        public void DeleteBewertungsBeschreibung(int bewertungsBeschreibungId)
        {
            using (LiteDatabase db = new LiteDatabase("BewertungsBeschreibung1.0.db", null))
            {
                db.GetCollection<BewertungsBeschreibung>("BewertungsBeschreibung").Delete(x => x.Id == bewertungsBeschreibungId);
            }
        }

        public void UpdateBewertungsBeschreibung(BewertungsBeschreibung bewertungsBeschreibung, string vorname)
        {
            using (LiteDatabase db = new LiteDatabase("BewertungsBeschreibung1.0.db", null))
            {
                bewertungsBeschreibung.Beschreibung = TextEscaping.setKeywords(bewertungsBeschreibung.Beschreibung, vorname);

                db.GetCollection<BewertungsBeschreibung>("BewertungsBeschreibung").Update(bewertungsBeschreibung);
            }
        }

        public List<BewertungsBeschreibung> GetBewertungsBeschreibung(EnumKategorie kategorie, EnumSubKategorie subKategorie, EnumNote note, Lernende lernender)
        {
            using (LiteDatabase db = new LiteDatabase("BewertungsBeschreibung1.0.db", null))
            {
                var bewertungsBeschreibung = db.GetCollection<BewertungsBeschreibung>("BewertungsBeschreibung").Find((BewertungsBeschreibung x) => x.Kategorie.Equals(kategorie) && x.SubKategorie.Equals(subKategorie) && x.Note.Equals(note), 0, 2147483647).ToList();
                bewertungsBeschreibung.ForEach(item => {
                    item.Beschreibung = TextEscaping.removeKeywords(item.Beschreibung, lernender);
                });
                return bewertungsBeschreibung;
            }
        }
    }
}