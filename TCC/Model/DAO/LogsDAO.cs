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
            logInf.Acao = db.Acoes.Where(x => x.Id == logInf.Acao.Id).First();
            logInf.Usuario = db.Usuarios.Where(x => x.Id == logInf.Usuario.Id).First();

            db.Acoes.Attach(logInf.Acao);
            db.Usuarios.Attach(logInf.Usuario);
            db.Logs.Add(logInf);
            db.SaveChanges();
        }

        public IEnumerable<Logs> select()
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).ToList();
        }

        public Logs usuarioJaLogou()
        {
            try
            {
                int id = Variaveis.getIdUsuario();
                return db.Logs.Include(x => x.Usuario).Where(x => x.Usuario.Id == id).First();
            }
            catch
            {
                return null;
            }
        }
    }
}