using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class AgendamentosDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public AgendamentosDAO()
        {
            db = new ModelDB();
        }

        public void insertComProjeto(Agendamentos agendInf)
        {
            #region Inclusão de agendamento com projeto
            // "posiciona" no projeto selecionado
            agendInf.Projeto = db.Projetos.ToList().Where(x => x.Id == agendInf.Projeto.Id).First();
            db.Agendamentos.Add(agendInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de agendamento
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 28).First();
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();

                db.Acoes.Attach(log.Acao);
                db.Usuarios.Attach(log.Usuario);
                db.Logs.Add(log);
                db.SaveChanges();
            }
            catch
            {

            }
            #endregion
        }

        public void insertComObra(Agendamentos agendInf)
        {
            #region Inclusão de agendamento com obra
            // "posiciona" na obra selecionada
            agendInf.Obra = db.Obras.ToList().Where(x => x.Id == agendInf.Obra.Id).First();
            db.Agendamentos.Add(agendInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de agendamento
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 28).First();
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();

                db.Acoes.Attach(log.Acao);
                db.Usuarios.Attach(log.Usuario);
                db.Logs.Add(log);
                db.SaveChanges();
            }
            catch
            {

            }
            #endregion
        }

        public void update(Agendamentos agendInf)
        {
            #region Alteração de agendamento
            // posiciona no registro a ser alterado
            Agendamentos agendAlt = db.Agendamentos.Where(x => x.Id == agendInf.Id).First();
            // altera suas propriedades
            agendAlt.Assunto = agendInf.Assunto;
            agendAlt.Observacao = agendInf.Observacao;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de agendamento
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 29).First();
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();

                db.Acoes.Attach(log.Acao);
                db.Usuarios.Attach(log.Usuario);
                db.Logs.Add(log);
                db.SaveChanges();
            }
            catch
            {

            }
            #endregion
        }

        public void delete(int id)
        {
            #region Exclusão de agendamento
            // posiciona no registro a ser excluído
            Agendamentos agendExc = db.Agendamentos.Where(x => x.Id == id).First();
            db.Agendamentos.Remove(agendExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de agendamento
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 30).First();
                log.Data = DateTime.Today.ToString("dd/MM/yyyy");
                log.Hora = DateTime.Now.ToString("HH:mm");
                log.Usuario = usuariosDAO.select().Where(x => x.Id == FormLogin.getIdUsuario()).First();

                db.Acoes.Attach(log.Acao);
                db.Usuarios.Attach(log.Usuario);
                db.Logs.Add(log);
                db.SaveChanges();
            }
            catch
            {

            }
            #endregion
        }

        public IEnumerable<Agendamentos> select()
        {
            #region Lista de agendamentos
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Agendamentos.Include(x => x.Projeto).Include(x => x.Obra).ToList();
            #endregion
        }
    }
}