using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class RegCreaProjetoDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public RegCreaProjetoDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(RegCreaProjeto creaPInf)
        {
            creaPInf.Projeto = db.Projetos.Where(x => x.Id == creaPInf.Projeto.Id).First();
            creaPInf.Crea = db.RegCrea.Where(x => x.Id == creaPInf.Crea.Id).First();
            db.RegCreaProjeto.Add(creaPInf);
            db.SaveChanges();

            // Inserção de log de inserção de registro
            logsDAO.insert(37);
        }

        public void update(RegCreaProjeto creaPInf)
        {
            RegCreaProjeto creaPAlt = db.RegCreaProjeto.Where(x => x.Id == creaPInf.Id).First();
            creaPAlt.Crea = creaPInf.Crea;
            db.SaveChanges();

            // Inserção de log de alteração de registro
            logsDAO.insert(38);
        }

        public void delete(int id)
        {
            RegCreaProjeto creaPExc = db.RegCreaProjeto.Where(x => x.Id == id).First();
            db.RegCreaProjeto.Remove(creaPExc);
            db.SaveChanges();

            // Inserção de log de exclusão de registro
            logsDAO.insert(39);
        }

        public IEnumerable<RegCreaProjeto> select()
        {
            return db.RegCreaProjeto.Include(x => x.Projeto).Include(x => x.Crea).ToList();
        }
    }
}