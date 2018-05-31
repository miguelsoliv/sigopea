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

        public IEnumerable<Acoes> select()
        {
            #region Lista de ações
            return db.Acoes.ToList();
            #endregion
        }
    }
}