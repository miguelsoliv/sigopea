using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class ObservacoesDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public ObservacoesDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insertComCliente(Observacoes obsInf)
        {
            obsInf.Cliente = db.Clientes.Where(x => x.Id == obsInf.Cliente.Id).First();
            db.Observacoes.Add(obsInf);
            db.SaveChanges();

            // Inserção de log de inserção de observação
            logsDAO.insert(20);
        }

        public void insertComTrab(Observacoes obsInf)
        {
            obsInf.Trabalhador = db.Trabalhadores.Where(x => x.Id == obsInf.Trabalhador.Id).First();
            db.Observacoes.Add(obsInf);
            db.SaveChanges();

            // Inserção de log de inserção de observação
            logsDAO.insert(20);
        }

        public void insertComForn(Observacoes obsInf)
        {
            obsInf.Fornecedor = db.Fornecedores.Where(x => x.Id == obsInf.Fornecedor.Id).First();
            db.Observacoes.Add(obsInf);
            db.SaveChanges();

            // Inserção de log de inserção de observação
            logsDAO.insert(20);
        }

        public void update(Observacoes obsInf)
        {
            Observacoes obsAlt = db.Observacoes.Where(x => x.Id == obsInf.Id).First();
            obsAlt.Observacao = obsInf.Observacao;
            db.SaveChanges();

            // Inserção de log de alteração de observação
            logsDAO.insert(21);
        }

        public void delete(int id)
        {
            Observacoes observacaoExc = db.Observacoes.Where(x => x.Id == id).First();
            db.Observacoes.Remove(observacaoExc);
            db.SaveChanges();

            // Inserção de log de exclusão de observação
            logsDAO.insert(22);
        }

        public IEnumerable<Observacoes> select()
        {
            return db.Observacoes.Include(x => x.Cliente).Include(x => x.Trabalhador).Include(x => x.Fornecedor).ToList();
        }
    }
}