using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class ClientesDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public ClientesDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(Clientes clienteInf)
        {
            clienteInf.Cidade = db.Cidades.Where(x => x.Id == clienteInf.Cidade.Id).First();
            db.Clientes.Add(clienteInf);
            db.SaveChanges();

            // Inserção de log de inclusão de cliente
            logsDAO.insert(5);
        }

        public void update(Clientes clienteInf)
        {
            clienteInf.Cidade = db.Cidades.Where(x => x.Id == clienteInf.Cidade.Id).First();

            Clientes clienteAlt = db.Clientes.Where(x => x.Id == clienteInf.Id).First();
            clienteAlt.Cidade = clienteInf.Cidade;
            clienteAlt.Nome = clienteInf.Nome;
            clienteAlt.Email = clienteInf.Email;
            clienteAlt.Cpf = clienteInf.Cpf;
            clienteAlt.Cnpj = clienteInf.Cnpj;
            clienteAlt.Endereco = clienteInf.Endereco;
            clienteAlt.Telefone = clienteInf.Telefone;
            clienteAlt.Telefone2 = clienteInf.Telefone2;
            db.SaveChanges();

            // Inserção de log de alteração de cliente
            logsDAO.insert(6);
        }

        public void delete(int id)
        {
            Clientes clienteExc = db.Clientes.Where(x => x.Id == id).First();
            clienteExc.Excluido = true;
            db.SaveChanges();

            // Inserção de log de exclusão de cliente
            logsDAO.insert(7);
        }

        public IEnumerable<Clientes> select()
        {
            return db.Clientes.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
        }

        public Clientes select(int id)
        {
            // Selecionar cliente pelo ID, utilizado na parte de carregar os dados na alteração de cliente
            return db.Clientes.Include(x => x.Cidade).Where(x => x.Id == id).First();
        }
    }
}