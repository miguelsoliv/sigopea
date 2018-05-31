using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class RegCreaDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public RegCreaDAO()
        {
            db = new ModelDB();
        }

        public void insert(RegCrea creaInf)
        {
            #region Inclusão de registro crea
            db.RegCrea.Add(creaInf);
            db.SaveChanges();
            #endregion
        }

        public void update(RegCrea creaInf)
        {
            #region Alteração de registro crea
            // posiciona no registro a ser alterado
            RegCrea creaAlt = db.RegCrea.Where(x => x.Id == creaInf.Id).First();
            // altera suas propriedades
            creaAlt.Crea = creaInf.Crea;
            // salva o registro alterado
            db.SaveChanges();
            #endregion
        }

        public void delete(int id)
        {
            #region Exclusão de registro crea
            // posiciona no registro a ser excluído
            RegCrea creaExc = db.RegCrea.Where(x => x.Id == id).First();
            db.RegCrea.Remove(creaExc);
            db.SaveChanges();
            #endregion
        }

        public IEnumerable<RegCrea> select()
        {
            #region Lista de registros crea
            return db.RegCrea.ToList();
            #endregion
        }
    }
}