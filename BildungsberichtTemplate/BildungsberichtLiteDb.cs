namespace BildungsberichtTemplate
{
    using LiteDB;
    using System.Linq;

    public class BildungsberichtLiteDb
    {
        private const string Database = "Bildungsbericht1.0.db";

        private const string EntityName = "BildungsberichModels";

        public int InsertBildungsbericht(BildungsberichtModel bildungsbericht)
        {
            using (LiteDatabase db = new LiteDatabase("Bildungsbericht1.0.db", null))
            {
                return db.GetCollection<BildungsberichtModel>("BildungsberichModels").Insert(bildungsbericht);
            }
        }

        public void UpdateBildungsbericht(BildungsberichtModel bildungsbericht)
        {
            using (LiteDatabase db = new LiteDatabase("Bildungsbericht1.0.db", null))
            {
                db.GetCollection<BildungsberichtModel>("BildungsberichModels").Update(bildungsbericht);
            }
        }

        public BildungsberichtModel GetBildungsberichtById(int id)
        {
            using (LiteDatabase db = new LiteDatabase("Bildungsbericht1.0.db", null))
            {
                return db.GetCollection<BildungsberichtModel>("BildungsberichModels").Find((BildungsberichtModel x) => x.Id.Equals(id), 0, 2147483647).FirstOrDefault();
            }
        }

        public BildungsberichtModel GetBildungsberichtByLernender(string name, string vorname)
        {
            using (LiteDatabase db = new LiteDatabase("Bildungsbericht1.0.db", null))
            {
                return db.GetCollection<BildungsberichtModel>("BildungsberichModels").Find((BildungsberichtModel x) => x.Lernende.Name.Equals(name) && x.Lernende.Vorname.Equals(vorname), 0, 2147483647).FirstOrDefault();
            }
        }
    }

}
