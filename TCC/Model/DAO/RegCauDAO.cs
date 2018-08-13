using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class RegCauDAO
    {
        private ModelDB db { get; set; }

        public RegCauDAO()
        {
            db = new ModelDB();
        }

        public void insert(RegCau cauInf)
        {
            db.RegCau.Add(cauInf);
            db.SaveChanges();
        }

        public void update(RegCau cauInf)
        {
            RegCau cauAlt = db.RegCau.Where(x => x.Id == cauInf.Id).First();
            cauAlt.Cau = cauInf.Cau;
            db.SaveChanges();
        }

        public void delete(int id)
        {
            RegCau cauExc = db.RegCau.Where(x => x.Id == id).First();
            db.RegCau.Remove(cauExc);
            db.SaveChanges();
        }

        public IEnumerable<RegCau> select()
        {
            return db.RegCau.ToList();
        }
    }
}