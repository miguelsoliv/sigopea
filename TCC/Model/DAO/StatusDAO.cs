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

        public IEnumerable<Status> select()
        {
            #region Lista de status das obras/projetos
            return db.Status.ToList();
            #endregion
        }
    }
}