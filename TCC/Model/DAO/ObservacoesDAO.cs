using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class ObservacoesDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObservacoesDAO()
        {
            db = new ModelDB();
        }

        public void insertComCliente(Observacoes obsInf)
        {
            #region Inclusão de observação com cliente
            // "posiciona" no cliente selecionado
            obsInf.Cliente = db.Clientes.ToList().Where(x => x.Id == obsInf.Cliente.Id).First();
            db.Observacoes.Add(obsInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inserção de observação
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 20).First();
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

        public void insertComTrab(Observacoes obsInf)
        {
            #region Inclusão de observação com trabalhador
            // "posiciona" no trabalhador selecionado
            obsInf.Trabalhador = db.Trabalhadores.ToList().Where(x => x.Id == obsInf.Trabalhador.Id).First();
            db.Observacoes.Add(obsInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inserção de observação
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 20).First();
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

        public void insertComForn(Observacoes obsInf)
        {
            #region Inclusão de observação com fornecedor
            // "posiciona" no fornecedor selecionado
            obsInf.Fornecedor = db.Fornecedores.ToList().Where(x => x.Id == obsInf.Fornecedor.Id).First();
            db.Observacoes.Add(obsInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inserção de observação
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 20).First();
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

        public void update(Observacoes obsInf)
        {
            #region Alteração de observação
            // posiciona no registro a ser alterado
            Observacoes obsAlt = db.Observacoes.Where(x => x.Id == obsInf.Id).First();
            // altera suas propriedades
            obsAlt.Observacao = obsInf.Observacao;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de observação
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 21).First();
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
            #region Exclusão de observacao
            // posiciona no registro a ser excluído
            Observacoes observacaoExc = db.Observacoes.Where(x => x.Id == id).First();
            db.Observacoes.Remove(observacaoExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de observação
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 22).First();
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

        public IEnumerable<Observacoes> select()
        {
            #region Lista de observações
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Observacoes.Include(x => x.Cliente).Include(x => x.Trabalhador).Include(x => x.Fornecedor).ToList();
            #endregion
        }
    }
}