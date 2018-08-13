using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class ProjetosDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public ProjetosDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(Projetos projetoInf)
        {
            projetoInf.Cidade = db.Cidades.Where(x => x.Id == projetoInf.Cidade.Id).First();
            projetoInf.Cliente = db.Clientes.Where(x => x.Id == projetoInf.Cliente.Id).First();
            projetoInf.Status = db.Status.Where(x => x.Id == projetoInf.Status.Id).First();
            db.Projetos.Add(projetoInf);
            db.SaveChanges();

            // Inserção de log de inclusão de projeto
            logsDAO.insert(17);
        }

        public void update(Projetos projetoInf)
        {
            projetoInf.Cidade = db.Cidades.Where(x => x.Id == projetoInf.Cidade.Id).First();
            projetoInf.Cliente = db.Clientes.Where(x => x.Id == projetoInf.Cliente.Id).First();
            projetoInf.Status = db.Status.Where(x => x.Id == projetoInf.Status.Id).First();

            Projetos projetoAlt = db.Projetos.Where(x => x.Id == projetoInf.Id).First();
            projetoAlt.Cidade = projetoInf.Cidade;
            projetoAlt.Cliente = projetoInf.Cliente;
            projetoAlt.DataFim = projetoInf.DataFim;
            projetoAlt.DataInicio = projetoInf.DataInicio;
            projetoAlt.Endereco = projetoInf.Endereco;
            projetoAlt.Excluido = projetoInf.Excluido;
            projetoAlt.PrazoEstipulado = projetoInf.PrazoEstipulado;
            projetoAlt.Preco = projetoInf.Preco;
            projetoAlt.Status = projetoInf.Status;
            db.SaveChanges();

            // Inserção de log de alteração de projeto
            logsDAO.insert(18);
        }

        public void delete(int id)
        {
            Projetos projetoExc = db.Projetos.Where(x => x.Id == id).First();
            projetoExc.Excluido = true;
            db.SaveChanges();

            // Inserção de log de exclusão de projeto
            logsDAO.insert(19);
        }

        public IEnumerable<Projetos> select()
        {
            return db.Projetos.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status)
                .Where(x => x.Excluido != true).ToList();
        }

        public Projetos select(int id)
        {
            // Selecionar projeto pelo ID, utilizado na parte de carregar os dados na alteração de projeto
            return db.Projetos.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Where(x => x.Id == id).First();
        }
    }
}