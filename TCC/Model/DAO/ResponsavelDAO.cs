using System;
using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using TCC.View;

namespace TCC.Model.DAO
{
    class ResponsavelDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
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
            #region Inclusão de responsável
            db.Responsavel.Add(respInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de responsável
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 34).First();
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

        public void update(Responsavel respInf)
        {
            #region Alteração de responsável
            // posiciona no registro a ser alterado
            Responsavel respAlt = db.Responsavel.Where(x => x.Id == respInf.Id).First();
            // altera suas propriedades
            respAlt.Email = respInf.Email;
            respAlt.Nome = respInf.Nome;
            respAlt.Telefone = respInf.Telefone;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de responsável
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 35).First();
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
            #region Exclusão de responsável
            // posiciona no registro a ser excluído
            Responsavel respExc = db.Responsavel.Where(x => x.Id == id).First();
            db.Responsavel.Remove(respExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de responsável
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 36).First();
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

        public IEnumerable<Responsavel> select()
        {
            #region Lista de responsavel
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Responsavel.ToList();
            #endregion
        }
    }
}