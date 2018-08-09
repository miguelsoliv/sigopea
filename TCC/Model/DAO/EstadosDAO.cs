using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class EstadosDAO
    {
        private ModelDB db { get; set; }

        public EstadosDAO()
        {
            db = new ModelDB();
        }

        public void insert(Estados estadoInf)
        {
            db.Estados.Add(estadoInf);
            db.SaveChanges();
        }

        public IEnumerable<Estados> select()
        {
            return db.Estados.ToList();
        }
    }
}