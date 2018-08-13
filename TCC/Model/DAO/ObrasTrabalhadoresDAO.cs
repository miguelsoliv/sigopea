using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;

namespace TCC.Model.DAO
{
    class ObrasTrabalhadoresDAO
    {
        private ModelDB db { get; set; }
        private LogsDAO logsDAO { get; set; }

        public ObrasTrabalhadoresDAO()
        {
            db = new ModelDB();
            logsDAO = new LogsDAO();
        }

        public void insert(ObrasTrabalhadores otInf)
        {
            otInf.Trabalhador = db.Trabalhadores.Where(x => x.Id == otInf.Trabalhador.Id).First();
            otInf.Obra = db.Obras.Where(x => x.Id == otInf.Obra.Id).First();

            db.Trabalhadores.Attach(otInf.Trabalhador);
            db.Obras.Attach(otInf.Obra);
            db.ObrasTrabalhadores.Add(otInf);
            db.SaveChanges();

            logsDAO.insert(23);
        }

        public void delete(int idTrab, int idObra)
        {
            ObrasTrabalhadores otExc = db.ObrasTrabalhadores.Where(x => x.Trabalhador.Id == idTrab && x.Obra.Id == idObra).First();
            db.ObrasTrabalhadores.Remove(otExc);
            db.SaveChanges();

            logsDAO.insert(24);
        }

        public IEnumerable<ObrasTrabalhadores> select()
        {
            return db.ObrasTrabalhadores.Include(x => x.Trabalhador).Include(x => x.Obra).ToList();
        }
    }
}