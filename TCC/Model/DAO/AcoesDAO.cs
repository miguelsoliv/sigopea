using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class AcoesDAO
    {
        private ModelDB db { get; set; }

        public AcoesDAO()
        {
            db = new ModelDB();
        }

        public void insert(Acoes acaoInf)
        {
            db.Acoes.Add(acaoInf);
            db.SaveChanges();
        }

        public IEnumerable<Acoes> select()
        {
            return db.Acoes.ToList();
        }

        public Acoes select(int id)
        {
            try
            {
                return db.Acoes.Where(x => x.Id == id).First();
            }
            catch
            {
                return null;
            }
        }
    }
}