using System;
using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;

namespace TCC.Model.DAO
{
    class ResponsavelDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ResponsavelDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(Responsavel respInf)
        {
            db.Responsavel.Add(respInf);

            // Inserção de log de inclusão de responsável
            Logs log = new Logs();
            log.Acao = acoesDAO.select(34);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Responsavel respInf)
        {
            Responsavel respAlt = db.Responsavel.Where(x => x.Id == respInf.Id).First();
            respAlt.Email = respInf.Email;
            respAlt.Nome = respInf.Nome;
            respAlt.Telefone = respInf.Telefone;

            // Inserção de log de alteração de responsável
            Logs log = new Logs();
            log.Acao = acoesDAO.select(35);
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
            Responsavel respExc = db.Responsavel.Where(x => x.Id == id).First();
            db.Responsavel.Remove(respExc);

            // Inserção de log de exclusão de responsável
            Logs log = new Logs();
            log.Acao = acoesDAO.select(36);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Responsavel> select()
        {
            return db.Responsavel.ToList();
        }
    }
}