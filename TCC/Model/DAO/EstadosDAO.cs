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

        public IEnumerable<Estados> select()
        {
            #region Lista de estados
            return db.Estados.ToList();
            #endregion
        }
    }
}