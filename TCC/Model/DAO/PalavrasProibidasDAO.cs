using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class PalavrasProibidasDAO
    {
        private ModelDB db { get; set; }

        public PalavrasProibidasDAO()
        {
            db = new ModelDB();
        }

        public void insert(PalavrasProibidas palavraInf)
        {
            db.PalavrasProibidas.Add(palavraInf);
            db.SaveChanges();
        }

        public void update(PalavrasProibidas palavraInf)
        {
            PalavrasProibidas palavraAlt = db.PalavrasProibidas.Where(x => x.Id == palavraInf.Id).First();
            palavraAlt.Palavra = palavraInf.Palavra;
            db.SaveChanges();
        }

        public void delete(int id)
        {
            PalavrasProibidas palavraExc = db.PalavrasProibidas.Where(x => x.Id == id).First();
            db.PalavrasProibidas.Remove(palavraExc);
            db.SaveChanges();
        }

        public IEnumerable<PalavrasProibidas> select()
        {
            return db.PalavrasProibidas.ToList();
        }

        public PalavrasProibidas select(int id)
        {
            // Selecionar palavra proibida pelo ID, utilizado na parte de carregar os dados na alteração de palavra proibida
            return db.PalavrasProibidas.Where(x => x.Id == id).First();
        }
    }
}