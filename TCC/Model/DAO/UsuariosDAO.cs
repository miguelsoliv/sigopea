using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class UsuariosDAO
    {
        private ModelDB db { get; set; }

        public UsuariosDAO()
        {
            db = new ModelDB();
        }

        public void insert(Usuarios usuarioInf)
        {
            #region Inclusão de usuário
            db.Usuarios.Add(usuarioInf);
            db.SaveChanges();
            #endregion
        }

        public IEnumerable<Usuarios> select()
        {
            #region Lista de usuários
            return db.Usuarios.ToList();
            #endregion
        }
    }
}