using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class PalavrasProibidasDAO
    {
        private ModelDB db { get; set; }

        public PalavrasProibidasDAO()
        {
            db = new ModelDB();
        }

        public void insert(PalavrasProibidas palavraInf)
        {
            #region Inclusão de palavra proibida
            db.PalavrasProibidas.Add(palavraInf);
            db.SaveChanges();
            #endregion
        }

        public void update(PalavrasProibidas palavraInf)
        {
            #region Alteração de palavra proibida
            // posiciona no registro a ser alterado
            PalavrasProibidas palavraAlt = db.PalavrasProibidas.Where(x => x.Id == palavraInf.Id).First();
            // altera suas propriedades
            palavraAlt.Palavra = palavraInf.Palavra;
            // salva o registro alterado
            db.SaveChanges();
            #endregion
        }

        public void delete(int id)
        {
            #region Exclusão de palavra proibida
            // posiciona no registro a ser excluído
            PalavrasProibidas palavraExc = db.PalavrasProibidas.Where(x => x.Id == id).First();
            db.PalavrasProibidas.Remove(palavraExc);
            db.SaveChanges();
            #endregion
        }

        public IEnumerable<PalavrasProibidas> select()
        {
            #region Lista de palavras proibidas
            return db.PalavrasProibidas.ToList();
            #endregion
        }

        public IEnumerable<PalavrasProibidas> select(int id)
        {
            #region Selecionar palavra proibida pelo seu ID
            // Selecionar palavra proibida pelo ID, utilizado na parte de carregar os dados na alteração de palavra proibida
            return db.PalavrasProibidas.ToList().Where(x => x.Id == id);
            #endregion
        }
    }
}