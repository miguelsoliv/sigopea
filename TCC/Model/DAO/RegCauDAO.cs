using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class RegCauDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public RegCauDAO()
        {
            db = new ModelDB();
        }

        public void insert(RegCau cauInf)
        {
            #region Inclusão de registro cau
            db.RegCau.Add(cauInf);
            db.SaveChanges();
            #endregion
        }

        public void update(RegCau cauInf)
        {
            #region Alteração de registro cau
            // posiciona no registro a ser alterado
            RegCau cauAlt = db.RegCau.Where(x => x.Id == cauInf.Id).First();
            // altera suas propriedades
            cauAlt.Cau = cauInf.Cau;
            // salva o registro alterado
            db.SaveChanges();
            #endregion
        }

        public void delete(int id)
        {
            #region Exclusão de registro cau
            // posiciona no registro a ser excluído
            RegCau cauExc = db.RegCau.Where(x => x.Id == id).First();
            db.RegCau.Remove(cauExc);
            db.SaveChanges();
            #endregion
        }

        public IEnumerable<RegCau> select()
        {
            #region Lista de registros cau
            return db.RegCau.ToList();
            #endregion
        }
    }
}