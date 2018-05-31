using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class LogsDAO
    {
        private ModelDB db { get; set; }

        public LogsDAO()
        {
            db = new ModelDB();
        }

        public void insert(Logs logInf)
        {
            #region Inclusão de log
            // "posiciona" na ação/usuário selecionada
            logInf.Acao = db.Acoes.ToList().Where(x => x.Id == logInf.Acao.Id).First();
            logInf.Usuario = db.Usuarios.ToList().Where(x => x.Id == logInf.Usuario.Id).First();

            db.Acoes.Attach(logInf.Acao);
            db.Usuarios.Attach(logInf.Usuario);
            db.Logs.Add(logInf);
            db.SaveChanges();
            #endregion
        }

        public IEnumerable<Logs> select()
        {
            #region Lista de logs
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).ToList();
            #endregion
        }
    }
}