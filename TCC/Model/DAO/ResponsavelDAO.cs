using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class ResponsavelDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public ResponsavelDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(Responsavel respInf)
        {
            db.Responsavel.Add(respInf);
            db.SaveChanges();

            // Inserção de log de inclusão de responsável
            logsDAO.insert(34);
        }

        public void update(Responsavel respInf)
        {
            Responsavel respAlt = db.Responsavel.Where(x => x.Id == respInf.Id).First();
            respAlt.Email = respInf.Email;
            respAlt.Nome = respInf.Nome;
            respAlt.Telefone = respInf.Telefone;
            db.SaveChanges();

            // Inserção de log de alteração de responsável
            logsDAO.insert(35);
        }

        public void delete(int id)
        {
            Responsavel respExc = db.Responsavel.Where(x => x.Id == id).First();
            db.Responsavel.Remove(respExc);
            db.SaveChanges();

            // Inserção de log de exclusão de responsável
            logsDAO.insert(36);
        }

        public IEnumerable<Responsavel> select()
        {
            return db.Responsavel.ToList();
        }
    }
}