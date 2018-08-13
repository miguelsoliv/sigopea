using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class ObrasDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public ObrasDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(Obras obraInf)
        {
            obraInf.Cidade = db.Cidades.Where(x => x.Id == obraInf.Cidade.Id).First();
            obraInf.Cliente = db.Clientes.Where(x => x.Id == obraInf.Cliente.Id).First();
            obraInf.Status = db.Status.Where(x => x.Id == obraInf.Status.Id).First();
            try
            {
                obraInf.Responsavel = db.Responsavel.Where(x => x.Id == obraInf.Responsavel.Id).First();
            }
            catch
            {

            }
            db.Obras.Add(obraInf);
            db.SaveChanges();

            // Inserção de log de inclusão de obra
            logsDAO.insert(14);
        }

        public void update(Obras obraInf)
        {
            obraInf.Cidade = db.Cidades.Where(x => x.Id == obraInf.Cidade.Id).First();
            obraInf.Cliente = db.Clientes.Where(x => x.Id == obraInf.Cliente.Id).First();
            obraInf.Status = db.Status.Where(x => x.Id == obraInf.Status.Id).First();
            try
            {
                obraInf.Responsavel = db.Responsavel.Where(x => x.Id == obraInf.Responsavel.Id).First();
            }
            catch
            {

            }

            Obras obraAlt = db.Obras.Where(x => x.Id == obraInf.Id).First();
            obraAlt.Cidade = obraInf.Cidade;
            obraAlt.Cliente = obraInf.Cliente;
            obraAlt.DataFim = obraInf.DataFim;
            obraAlt.DataInicio = obraInf.DataInicio;
            obraAlt.Endereco = obraInf.Endereco;
            obraAlt.Excluido = obraInf.Excluido;
            obraAlt.PrazoEstipulado = obraInf.PrazoEstipulado;
            obraAlt.Preco = obraInf.Preco;
            obraAlt.Responsavel = obraInf.Responsavel;
            obraAlt.Status = obraInf.Status;
            db.SaveChanges();

            // Inserção de log de alteração de obra
            logsDAO.insert(15);
        }

        public void delete(int id)
        {
            Obras obraExc = db.Obras.Where(x => x.Id == id).First();
            obraExc.Excluido = true;
            db.SaveChanges();

            // Inserção de log de exclusão de obra
            logsDAO.insert(16);
        }

        public IEnumerable<Obras> select()
        {
            return db.Obras.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Include(x => x.Responsavel)
                .Where(x => x.Excluido != true).ToList();
        }

        public Obras select(int id)
        {
            // Selecionar obra pelo ID, utilizado na parte de carregar os dados na alteração de obra
            return db.Obras.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Include(x => x.Responsavel)
                .Where(x => x.Id == id).First();
        }
    }
}