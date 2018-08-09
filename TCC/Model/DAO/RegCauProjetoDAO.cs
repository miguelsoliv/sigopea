using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class RegCauProjetoDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public RegCauProjetoDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(RegCauProjeto cauPInf)
        {
            cauPInf.Projeto = db.Projetos.Where(x => x.Id == cauPInf.Projeto.Id).First();
            cauPInf.Cau = db.RegCau.Where(x => x.Id == cauPInf.Cau.Id).First();
            db.RegCauProjeto.Add(cauPInf);

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

        public void update(RegCauProjeto cauPInf)
        {
            RegCauProjeto cauPAlt = db.RegCauProjeto.Where(x => x.Id == cauPInf.Id).First();
            cauPAlt.Cau = cauPInf.Cau;

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
            RegCauProjeto cauPExc = db.RegCauProjeto.Where(x => x.Id == id).First();
            db.RegCauProjeto.Remove(cauPExc);

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

        public IEnumerable<RegCauProjeto> select()
        {
            return db.RegCauProjeto.Include(x => x.Projeto).Include(x => x.Cau).ToList();
        }
    }
}