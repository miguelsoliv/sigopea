using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class StatusDAO
    {
        private ModelDB db { get; set; }

        public StatusDAO()
        {
            db = new ModelDB();
        }

        public void insert(Status statusInf)
        {
            db.Status.Add(statusInf);
            db.SaveChanges();
        }

        public IEnumerable<Status> select()
        {
            return db.Status.ToList();
        }

        public int checarInserts()
        {
            return db.Status.ToList().Count();
        }
    }
}