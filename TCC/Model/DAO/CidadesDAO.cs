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
            #region Lista de cidades, com o comando SQL distinct
            return db.Cidades.Include(x => x.Estado).ToList().Distinct().OrderBy(x => x.Nome);
            #endregion
        }

        public IEnumerable<Cidades> selectPorEstado(int estado)
        {
            #region Lista de cidades, que recebe o código do estado como parâmetro
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Cidades.Include(x => x.Estado).ToList().Where(x => x.Estado.Id == estado);
            #endregion
        }

        public IEnumerable<Cidades> selectCidade(int id_cidade)
        {
            #region Select com somente uma cidade, que será utilizada na hora de carregar os dados do cliente/trabalhador/etc no groupBox
            return db.Cidades.Include(x => x.Estado).ToList().Where(x => x.Id == id_cidade);
            #endregion
        }
    }
}