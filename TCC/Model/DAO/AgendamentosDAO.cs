using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class AgendamentosDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public AgendamentosDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insertComProjeto(Agendamentos agendInf)
        {
            agendInf.Projeto = db.Projetos.Where(x => x.Id == agendInf.Projeto.Id).First();
            db.Agendamentos.Add(agendInf);
            db.SaveChanges();

            // Inserção de log de inclusão de agendamento
            logsDAO.insert(28);
        }

        public void insertComObra(Agendamentos agendInf)
        {
            agendInf.Obra = db.Obras.Where(x => x.Id == agendInf.Obra.Id).First();
            db.Agendamentos.Add(agendInf);
            db.SaveChanges();

            // Inserção de log de inclusão de agendamento
            logsDAO.insert(28);
        }

        public void update(Agendamentos agendInf)
        {
            Agendamentos agendAlt = db.Agendamentos.Where(x => x.Id == agendInf.Id).First();
            agendAlt.Assunto = agendInf.Assunto;
            agendAlt.Observacao = agendInf.Observacao;
            db.SaveChanges();

            // Inserção de log de alteração de agendamento
            logsDAO.insert(29);
        }

        public void delete(int id)
        {
            Agendamentos agendExc = db.Agendamentos.Where(x => x.Id == id).First();
            db.Agendamentos.Remove(agendExc);
            db.SaveChanges();

            // Inserção de log de exclusão de agendamento
            logsDAO.insert(30);
        }

        public IEnumerable<Agendamentos> select()
        {
            return db.Agendamentos.Include(x => x.Projeto).Include(x => x.Obra).ToList();
        }
    }
}