using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class ObrasFornecedoresDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public ObrasFornecedoresDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(ObrasFornecedores ofInf)
        {
            ofInf.Fornecedor = db.Fornecedores.Where(x => x.Id == ofInf.Fornecedor.Id).First();
            ofInf.Obra = db.Obras.Where(x => x.Id == ofInf.Obra.Id).First();

            db.Fornecedores.Attach(ofInf.Fornecedor);
            db.Obras.Attach(ofInf.Obra);
            db.ObrasFornecedores.Add(ofInf);
            db.SaveChanges();

            logsDAO.insert(25);
        }

        public void update(ObrasFornecedores ofInf)
        {
            ObrasFornecedores ofAlt = db.ObrasFornecedores.Where(x => x.Fornecedor.Id == ofInf.Fornecedor.Id && x.Obra.Id == ofInf.Obra.Id).First();
            ofAlt.Observacao = ofInf.Observacao;
            db.SaveChanges();

            logsDAO.insert(26);
        }

        public void delete(int idForn, int idObra)
        {
            ObrasFornecedores ofExc = db.ObrasFornecedores.Where(x => x.Fornecedor.Id == idForn && x.Obra.Id == idObra).First();
            db.ObrasFornecedores.Remove(ofExc);
            db.SaveChanges();

            logsDAO.insert(27);
        }

        public IEnumerable<ObrasFornecedores> select()
        {
            return db.ObrasFornecedores.Include(x => x.Fornecedor).Include(x => x.Obra).ToList();
        }
    }
}