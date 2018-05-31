using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class FornecedoresDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public FornecedoresDAO()
        {
            db = new ModelDB();
        }

        public void insert(Fornecedores fornecedorInf)
        {
            #region Inclusão de fornecedor
            // "posiciona" na cidade selecionada
            fornecedorInf.Cidade = db.Cidades.ToList().Where(x => x.Id == fornecedorInf.Cidade.Id).First();
            db.Fornecedores.Add(fornecedorInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de fornecedor
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 11).First();
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

        public void update(Fornecedores fornecedorInf)
        {
            #region Alteração de fornecedor
            // "posiciona" na cidade selecionada
            fornecedorInf.Cidade = db.Cidades.ToList().Where(x => x.Id == fornecedorInf.Cidade.Id).First();
            // posiciona no registro a ser alterado
            Fornecedores fornecedorAlt = db.Fornecedores.Where(x => x.Id == fornecedorInf.Id).First();
            // altera suas propriedades
            fornecedorAlt.Cidade = fornecedorInf.Cidade;
            fornecedorAlt.Nome = fornecedorInf.Nome;
            fornecedorAlt.Email = fornecedorInf.Email;
            fornecedorAlt.Endereco = fornecedorInf.Endereco;
            fornecedorAlt.Telefone = fornecedorInf.Telefone;
            fornecedorAlt.Telefone2 = fornecedorInf.Telefone2;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de fornecedor
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 12).First();
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
            #region Exclusão de fornecedor
            // posiciona no registro a ser excluído
            Fornecedores fornecedorExc = db.Fornecedores.Where(c => c.Id == id).First();
            fornecedorExc.Excluido = true;
            //db.Fornecedores.Remove(fornecedorExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de fornecedor
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 13).First();
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

        public IEnumerable<Fornecedores> select()
        {
            #region Lista de fornecedores
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Fornecedores.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
            #endregion
        }

        public IEnumerable<Fornecedores> select(int id)
        {
            #region Selecionar fornecedor pelo seu ID
            // Selecionar fornecedor pelo ID, utilizado na parte de carregar os dados na alteração de fornecedor
            return db.Fornecedores.Include(x => x.Cidade).ToList().Where(x => x.Id == id);
            #endregion
        }
    }
}