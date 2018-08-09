using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class AgendamentosDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public AgendamentosDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insertComProjeto(Agendamentos agendInf)
        {
            agendInf.Projeto = db.Projetos.Where(x => x.Id == agendInf.Projeto.Id).First();
            db.Agendamentos.Add(agendInf);

            // Inserção de log de inclusão de agendamento
            Logs log = new Logs();
            log.Acao = acoesDAO.select(28);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void insertComObra(Agendamentos agendInf)
        {
            agendInf.Obra = db.Obras.Where(x => x.Id == agendInf.Obra.Id).First();
            db.Agendamentos.Add(agendInf);

            // Inserção de log de inclusão de agendamento
            Logs log = new Logs();
            log.Acao = acoesDAO.select(28);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Agendamentos agendInf)
        {
            Agendamentos agendAlt = db.Agendamentos.Where(x => x.Id == agendInf.Id).First();
            agendAlt.Assunto = agendInf.Assunto;
            agendAlt.Observacao = agendInf.Observacao;

            // Inserção de log de alteração de agendamento
            Logs log = new Logs();
            log.Acao = acoesDAO.select(29);
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
            Agendamentos agendExc = db.Agendamentos.Where(x => x.Id == id).First();
            db.Agendamentos.Remove(agendExc);

            // Inserção de log de exclusão de agendamento
            Logs log = new Logs();
            log.Acao = acoesDAO.select(30);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Agendamentos> select()
        {
            return db.Agendamentos.Include(x => x.Projeto).Include(x => x.Obra).ToList();
        }
    }
}