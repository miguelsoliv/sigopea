using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class ObrasFornecedoresDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObrasFornecedoresDAO()
        {
            db = new ModelDB();
        }

        public void insert(ObrasFornecedores ofInf)
        {
            #region Inclusão de fornecedor relacionado a obra x
            // "posiciona" no trabalhador/obra selecionado
            ofInf.Fornecedor = db.Fornecedores.ToList().Where(x => x.Id == ofInf.Fornecedor.Id).First();
            ofInf.Obra = db.Obras.ToList().Where(x => x.Id == ofInf.Obra.Id).First();

            db.Fornecedores.Attach(ofInf.Fornecedor);
            db.Obras.Attach(ofInf.Obra);
            db.ObrasFornecedores.Add(ofInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de obras_fornecedores
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 25).First();
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

        public void update(ObrasFornecedores ofInf)
        {
            #region Alteração da observação do fornecedor
            // posiciona no registro a ser alterado
            ObrasFornecedores ofAlt = db.ObrasFornecedores.Where(x => x.Fornecedor.Id == ofInf.Fornecedor.Id && x.Obra.Id == ofInf.Obra.Id).First();
            // altera suas propriedades
            ofAlt.Observacao = ofInf.Observacao;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de obras_fornecedores
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 26).First();
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

        public void delete(int idForn, int idObra)
        {
            #region Exclusão da relação
            // posiciona no registro a ser excluído
            ObrasFornecedores ofExc = db.ObrasFornecedores.Where(x => x.Fornecedor.Id == idForn && x.Obra.Id == idObra).First();
            db.ObrasFornecedores.Remove(ofExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de obras_fornecedores
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 27).First();
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

        public IEnumerable<ObrasFornecedores> select()
        {
            #region Lista de fornecedores relacionados com as obras
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.ObrasFornecedores.Include(x => x.Fornecedor).Include(x => x.Obra).ToList();
            #endregion
        }
    }
}