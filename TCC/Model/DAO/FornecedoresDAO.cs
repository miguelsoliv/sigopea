using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class FornecedoresDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public FornecedoresDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(Fornecedores fornecedorInf)
        {
            fornecedorInf.Cidade = db.Cidades.Where(x => x.Id == fornecedorInf.Cidade.Id).First();
            db.Fornecedores.Add(fornecedorInf);
            db.SaveChanges();

            // Inserção de log de inclusão de fornecedor
            logsDAO.insert(11);
        }

        public void update(Fornecedores fornecedorInf)
        {
            fornecedorInf.Cidade = db.Cidades.Where(x => x.Id == fornecedorInf.Cidade.Id).First();

            Fornecedores fornecedorAlt = db.Fornecedores.Where(x => x.Id == fornecedorInf.Id).First();
            fornecedorAlt.Cidade = fornecedorInf.Cidade;
            fornecedorAlt.Nome = fornecedorInf.Nome;
            fornecedorAlt.Email = fornecedorInf.Email;
            fornecedorAlt.Endereco = fornecedorInf.Endereco;
            fornecedorAlt.Telefone = fornecedorInf.Telefone;
            fornecedorAlt.Telefone2 = fornecedorInf.Telefone2;
            db.SaveChanges();
            
            // Inserção de log de alteração de fornecedor
            logsDAO.insert(12);
        }

        public void delete(int id)
        {
            Fornecedores fornecedorExc = db.Fornecedores.Where(x => x.Id == id).First();
            fornecedorExc.Excluido = true;
            db.SaveChanges();
            
            // Inserção de log de exclusão de fornecedor
            logsDAO.insert(13);
        }

        public IEnumerable<Fornecedores> select()
        {
            return db.Fornecedores.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
        }

        public Fornecedores select(int id)
        {
            // Selecionar fornecedor pelo ID, utilizado na parte de carregar os dados na alteração de fornecedor
            return db.Fornecedores.Include(x => x.Cidade).Where(x => x.Id == id).First();
        }
    }
}