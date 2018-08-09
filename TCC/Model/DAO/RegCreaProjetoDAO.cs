using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class RegCreaProjetoDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public RegCreaProjetoDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(RegCreaProjeto creaPInf)
        {
            creaPInf.Projeto = db.Projetos.Where(x => x.Id == creaPInf.Projeto.Id).First();
            creaPInf.Crea = db.RegCrea.Where(x => x.Id == creaPInf.Crea.Id).First();
            db.RegCreaProjeto.Add(creaPInf);

            // Inserção de log de inserção de registro
            Logs log = new Logs();
            log.Acao = acoesDAO.select(37);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(RegCreaProjeto creaPInf)
        {
            RegCreaProjeto creaPAlt = db.RegCreaProjeto.Where(x => x.Id == creaPInf.Id).First();
            creaPAlt.Crea = creaPInf.Crea;

            // Inserção de log de alteração de registro
            Logs log = new Logs();
            log.Acao = acoesDAO.select(38);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void delete(int id)
        {
            RegCreaProjeto creaPExc = db.RegCreaProjeto.Where(x => x.Id == id).First();
            db.RegCreaProjeto.Remove(creaPExc);

            // Inserção de log de exclusão de registro
            Logs log = new Logs();
            log.Acao = acoesDAO.select(39);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<RegCreaProjeto> select()
        {
            return db.RegCreaProjeto.Include(x => x.Projeto).Include(x => x.Crea).ToList();
        }
    }
}