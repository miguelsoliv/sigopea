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
            db.Usuarios.Add(usuarioInf);
            db.SaveChanges();
        }

        public void update(Usuarios usuarioInf)
        {
            Usuarios usuarioAlt = db.Usuarios.Where(x => x.Id == usuarioInf.Id).First();
            usuarioAlt.Email = usuarioInf.Email;
            usuarioAlt.Login = usuarioInf.Login;
            usuarioAlt.Senha = usuarioInf.Senha;
            usuarioAlt.Tipo = usuarioInf.Tipo;
            db.SaveChanges();
        }

        public void delete(int id)
        {
            Usuarios usuarioAlt = db.Usuarios.Where(x => x.Id == id).First();
            usuarioAlt.Excluido = true;
            db.SaveChanges();
        }

        public IEnumerable<Usuarios> select()
        {
            return db.Usuarios.ToList();
        }

        public Usuarios select(int id)
        {
            // Utilizado para vincular o usuário ao log
            return db.Usuarios.Where(x => x.Id == id).First();
        }

        public Usuarios selectLogin(string login, string senha)
        {
            // Verificar se existe um usuário com as credenciais informadas (login)
            try
            {
                return db.Usuarios.Where(x => x.Login == login.Trim() && x.Senha == senha).First();
            }
            catch
            {
                return null;
            }
        }

        public Usuarios selectEmail(string email, string senha)
        {
            // Verificar se existe um usuário com as credenciais informadas (RecupDados)
            return db.Usuarios.Where(x => x.Email == email.Trim() && x.Senha == senha).First();
        }

        public bool validacaoLogin(string login)
        {
            // Verificar se já existe um usuário com o login informado
            if (select().Where(x => x.Login.ToUpper() == login.Trim().ToUpper()).Count() == 1)
            {
                return false;
            }

            return true;
        }

        public bool validacaoEmail(string email)
        {
            // Verificar se já existe um usuário com o e-mail informado
            if (select().Where(x => x.Email.ToUpper() == email.Trim().ToUpper()).Count() == 1)
            {
                return false;
            }

            return true;
        }
    }
}