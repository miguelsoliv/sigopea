using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class RegCauProjetoDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public RegCauProjetoDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(RegCauProjeto cauPInf)
        {
            cauPInf.Projeto = db.Projetos.Where(x => x.Id == cauPInf.Projeto.Id).First();
            cauPInf.Cau = db.RegCau.Where(x => x.Id == cauPInf.Cau.Id).First();
            db.RegCauProjeto.Add(cauPInf);
            db.SaveChanges();

            // Inserção de log de inserção de registro
            logsDAO.insert(37);
        }

        public void update(RegCauProjeto cauPInf)
        {
            RegCauProjeto cauPAlt = db.RegCauProjeto.Where(x => x.Id == cauPInf.Id).First();
            cauPAlt.Cau = cauPInf.Cau;
            db.SaveChanges();

            // Inserção de log de alteração de registro
            logsDAO.insert(38);
        }

        public void delete(int id)
        {
            RegCauProjeto cauPExc = db.RegCauProjeto.Where(x => x.Id == id).First();
            db.RegCauProjeto.Remove(cauPExc);
            db.SaveChanges();

            // Inserção de log de exclusão de registro
            logsDAO.insert(39);
        }

        public IEnumerable<RegCauProjeto> select()
        {
            return db.RegCauProjeto.Include(x => x.Projeto).Include(x => x.Cau).ToList();
        }
    }
}