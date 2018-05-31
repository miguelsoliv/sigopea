using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class ProjetosDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ProjetosDAO()
        {
            db = new ModelDB();
        }

        public void insert(Projetos projetoInf)
        {
            #region Inclusão de projeto
            // "posiciona" na cidade/cliente/status selecionados
            projetoInf.Cidade = db.Cidades.ToList().Where(x => x.Id == projetoInf.Cidade.Id).First();
            projetoInf.Cliente = db.Clientes.ToList().Where(x => x.Id == projetoInf.Cliente.Id).First();
            projetoInf.Status = db.Status.ToList().Where(x => x.Id == projetoInf.Status.Id).First();
            db.Projetos.Add(projetoInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de projeto
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 17).First();
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

        public void update(Projetos projetoInf)
        {
            #region Alteração de projeto
            // "posiciona" na cidade/cliente/status selecionados
            projetoInf.Cidade = db.Cidades.ToList().Where(x => x.Id == projetoInf.Cidade.Id).First();
            projetoInf.Cliente = db.Clientes.ToList().Where(x => x.Id == projetoInf.Cliente.Id).First();
            projetoInf.Status = db.Status.ToList().Where(x => x.Id == projetoInf.Status.Id).First();
            // posiciona no registro a ser alterado
            Projetos projetoAlt = db.Projetos.Where(x => x.Id == projetoInf.Id).First();
            // altera suas propriedades
            projetoAlt.Cidade = projetoInf.Cidade;
            projetoAlt.Cliente = projetoInf.Cliente;
            projetoAlt.DataFim = projetoInf.DataFim;
            projetoAlt.DataInicio = projetoInf.DataInicio;
            projetoAlt.Endereco = projetoInf.Endereco;
            projetoAlt.Excluido = projetoInf.Excluido;
            projetoAlt.PrazoEstipulado = projetoInf.PrazoEstipulado;
            projetoAlt.Preco = projetoInf.Preco;
            projetoAlt.Status = projetoInf.Status;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de projeto
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 18).First();
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
            #region Exclusão de projeto
            // posiciona no registro a ser excluído
            Projetos projetoExc = db.Projetos.Where(x => x.Id == id).First();
            projetoExc.Excluido = true;
            //db.Projetos.Remove(projetoExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de projeto
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 19).First();
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

        public IEnumerable<Projetos> select()
        {
            #region Lista de projetos
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Projetos.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Where(x => x.Excluido != true).ToList();
            #endregion
        }

        public IEnumerable<Projetos> select(int id)
        {
            #region Selecionar projeto pelo seu ID
            // Selecionar projeto pelo ID, utilizado na parte de carregar os dados na alteração de projeto
            return db.Projetos.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).ToList().Where(x => x.Id == id);
            #endregion
        }
    }
}