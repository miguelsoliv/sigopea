using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class RegCreaProjetoDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public RegCreaProjetoDAO()
        {
            db = new ModelDB();
        }

        public void insert(RegCreaProjeto creaPInf)
        {
            #region Inclusão de registro crea_projeto
            // "posiciona" no projeto/crea selecionado
            creaPInf.Projeto = db.Projetos.ToList().Where(x => x.Id == creaPInf.Projeto.Id).First();
            creaPInf.Crea = db.RegCrea.ToList().Where(x => x.Id == creaPInf.Crea.Id).First();
            db.RegCreaProjeto.Add(creaPInf);
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

        public void update(RegCreaProjeto creaPInf)
        {
            #region Alteração de registro crea_projeto
            // posiciona no registro a ser alterado
            RegCreaProjeto creaPAlt = db.RegCreaProjeto.Where(x => x.Id == creaPInf.Id).First();
            // altera suas propriedades
            creaPAlt.Crea = creaPInf.Crea;
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
            #region Exclusão de registro crea_projeto
            // posiciona no registro a ser excluído
            RegCreaProjeto creaPExc = db.RegCreaProjeto.Where(x => x.Id == id).First();
            db.RegCreaProjeto.Remove(creaPExc);
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

        public IEnumerable<RegCreaProjeto> select()
        {
            #region Lista de registros crea_projeto
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.RegCreaProjeto.Include(x => x.Projeto).Include(x => x.Crea).ToList();
            #endregion
        }
    }
}