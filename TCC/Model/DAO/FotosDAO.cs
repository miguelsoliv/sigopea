using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class FotosDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public FotosDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(Fotos fotoInf)
        {
            fotoInf.Obra = db.Obras.Where(x => x.Id == fotoInf.Obra.Id).First();
            db.Fotos.Add(fotoInf);
            db.SaveChanges();

            // Inserção de log de inclusão de foto
            logsDAO.insert(31);
        }

        public void update(Fotos fotoInf)
        {
            Fotos fotoAlt = db.Fotos.Where(x => x.Id == fotoInf.Id).First();
            fotoAlt.Descricao = fotoInf.Descricao;
            db.SaveChanges();

            // Inserção de log de alteração de foto
            logsDAO.insert(32);
        }

        public void delete(int id)
        {
            Fotos fotoExc = db.Fotos.Where(x => x.Id == id).First();
            db.Fotos.Remove(fotoExc);
            db.SaveChanges();

            // Inserção de log de exclusão de foto
            logsDAO.insert(33);    
        }

        public IEnumerable<Fotos> select()
        {
            return db.Fotos.Include(x => x.Obra).ToList();
        }
    }
}