using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class RegCauProjetoDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public RegCauProjetoDAO()
        {
            db = new ModelDB();
        }

        public void insert(RegCauProjeto cauPInf)
        {
            #region Inclusão de registro cau_projeto
            // "posiciona" no projeto/crea selecionado
            cauPInf.Projeto = db.Projetos.ToList().Where(x => x.Id == cauPInf.Projeto.Id).First();
            cauPInf.Cau = db.RegCau.ToList().Where(x => x.Id == cauPInf.Cau.Id).First();
            db.RegCauProjeto.Add(cauPInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inserção de registro
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 37).First();
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

        public void update(RegCauProjeto cauPInf)
        {
            #region Alteração de registro cau_projeto
            // posiciona no registro a ser alterado
            RegCauProjeto cauPAlt = db.RegCauProjeto.Where(x => x.Id == cauPInf.Id).First();
            // altera suas propriedades
            cauPAlt.Cau = cauPInf.Cau;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de registro
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 38).First();
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
            #region Exclusão de registro cau_projeto
            // posiciona no registro a ser excluído
            RegCauProjeto cauPExc = db.RegCauProjeto.Where(x => x.Id == id).First();
            db.RegCauProjeto.Remove(cauPExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de registro
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 39).First();
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

        public IEnumerable<RegCauProjeto> select()
        {
            #region Lista de registros cau_projeto
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.RegCauProjeto.Include(x => x.Projeto).Include(x => x.Cau).ToList();
            #endregion
        }
    }
}