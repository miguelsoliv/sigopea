using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TCC.Model.Classes;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class ClientesDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ClientesDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(Clientes clienteInf)
        {
            #region Inclusão de cliente
            // "posiciona" na cidade selecionada
            clienteInf.Cidade = db.Cidades.ToList().Where(x => x.Id == clienteInf.Cidade.Id).First();
            db.Clientes.Add(clienteInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de cliente
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 5).First();
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

        public void update(Clientes clienteInf)
        {
            #region Alteração de cliente
            // "posiciona" na cidade selecionada
            clienteInf.Cidade = db.Cidades.ToList().Where(x => x.Id == clienteInf.Cidade.Id).First();
            // posiciona no registro a ser alterado
            Clientes clienteAlt = db.Clientes.Where(x => x.Id == clienteInf.Id).First();
            // altera suas propriedades
            clienteAlt.Cidade = clienteInf.Cidade;
            clienteAlt.Nome = clienteInf.Nome;
            clienteAlt.Email = clienteInf.Email;
            clienteAlt.Cpf = clienteInf.Cpf;
            clienteAlt.Cnpj = clienteInf.Cnpj;
            clienteAlt.Endereco = clienteInf.Endereco;
            clienteAlt.Telefone = clienteInf.Telefone;
            clienteAlt.Telefone2 = clienteInf.Telefone2;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de cliente
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 6).First();
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
            #region Exclusão de cliente
            // posiciona no registro a ser excluído
            Clientes clienteExc = db.Clientes.Where(x => x.Id == id).First();
            clienteExc.Excluido = true;
            //db.Clientes.Remove(clienteExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de cliente
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 7).First();
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

        public IEnumerable<Clientes> select()
        {
            #region Lista de clientes
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Clientes.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
            #endregion
        }

        public IEnumerable<Clientes> select(int id)
        {
            #region Selecionar cliente pelo seu ID
            // Selecionar cliente pelo ID, utilizado na parte de carregar os dados na alteração de cliente
            return db.Clientes.Include(x => x.Cidade).ToList().Where(x => x.Id == id);
            #endregion
        }
    }
}