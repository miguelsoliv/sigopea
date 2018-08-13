using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class TrabalhadoresDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public TrabalhadoresDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(Trabalhadores trabalhadorInf)
        {
            trabalhadorInf.Cidade = db.Cidades.Where(x => x.Id == trabalhadorInf.Cidade.Id).First();
            db.Trabalhadores.Add(trabalhadorInf);
            db.SaveChanges();

            // Inserção de log de inclusão de trabalhador
            logsDAO.insert(8);
        }

        public void update(Trabalhadores trabalhadorInf)
        {
            trabalhadorInf.Cidade = db.Cidades.Where(x => x.Id == trabalhadorInf.Cidade.Id).First();

            Trabalhadores trabalhadorAlt = db.Trabalhadores.Where(x => x.Id == trabalhadorInf.Id).First();
            trabalhadorAlt.Cidade = trabalhadorInf.Cidade;
            trabalhadorAlt.Nome = trabalhadorInf.Nome;
            trabalhadorAlt.Email = trabalhadorInf.Email;
            trabalhadorAlt.Cpf = trabalhadorInf.Cpf;
            trabalhadorAlt.Servico = trabalhadorInf.Servico;
            trabalhadorAlt.Endereco = trabalhadorInf.Endereco;
            trabalhadorAlt.Telefone = trabalhadorInf.Telefone;
            trabalhadorAlt.Telefone2 = trabalhadorInf.Telefone2;
            db.SaveChanges();

            // Inserção de log de alteração de trabalhador
            logsDAO.insert(9);
        }

        public void delete(int id)
        {
            Trabalhadores trabalhadorExc = db.Trabalhadores.Where(x => x.Id == id).First();
            trabalhadorExc.Excluido = true;
            db.SaveChanges();

            // Inserção de log de exclusão de trabalhador
            logsDAO.insert(10);
        }

        public IEnumerable<Trabalhadores> select()
        {
            return db.Trabalhadores.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
        }

        public Trabalhadores select(int id)
        {
            // Selecionar trabalhador pelo ID, utilizado na parte de carregar os dados na alteração de trabalhador
            return db.Trabalhadores.Include(x => x.Cidade).Where(x => x.Id == id).First();
        }
    }
}