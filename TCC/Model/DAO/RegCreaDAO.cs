using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class RegCreaDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public RegCreaDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(RegCrea creaInf)
        {
            db.RegCrea.Add(creaInf);
            db.SaveChanges();
        }

        public void update(RegCrea creaInf)
        {
            RegCrea creaAlt = db.RegCrea.Where(x => x.Id == creaInf.Id).First();
            creaAlt.Crea = creaInf.Crea;
            db.SaveChanges();
        }

        public void delete(int id)
        {
            RegCrea creaExc = db.RegCrea.Where(x => x.Id == id).First();
            db.RegCrea.Remove(creaExc);
            db.SaveChanges();
        }

        public IEnumerable<RegCrea> select()
        {
            return db.RegCrea.ToList();
        }
    }
}