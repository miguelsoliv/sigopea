using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class CidadesDAO
    {
        private ModelDB db { get; set; }

        public CidadesDAO()
        {
            db = new ModelDB();
        }

        public IEnumerable<Cidades> select()
        {
            return db.Cidades.Include(x => x.Estado).Distinct().OrderBy(x => x.Nome).ToList();
        }

        public IEnumerable<Cidades> selectPorEstado(int estado)
        {
            return db.Cidades.Include(x => x.Estado).Where(x => x.Estado.Id == estado).ToList();
        }

        public Cidades selectCidade(int id)
        {
            // Select com somente uma cidade, que será utilizada na hora de carregar os dados do cliente/trabalhador/etc no groupBox
            return db.Cidades.Include(x => x.Estado).Where(x => x.Id == id).First();
        }
    }
}