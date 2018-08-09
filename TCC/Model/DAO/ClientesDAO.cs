using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TCC.Model.Classes;
using System;

namespace TCC.Model.DAO
{
    class ClientesDAO
    {
        private ModelDB db { get; set; }
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
            clienteInf.Cidade = db.Cidades.Where(x => x.Id == clienteInf.Cidade.Id).First();
            db.Clientes.Add(clienteInf);

            // Inserção de log de inclusão de cliente
            Logs log = new Logs();
            log.Acao = acoesDAO.select(5);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Clientes clienteInf)
        {
            #region Alteração de cliente
            clienteInf.Cidade = db.Cidades.Where(x => x.Id == clienteInf.Cidade.Id).First();
            // posiciona no registro a ser alterado
            Clientes clienteAlt = db.Clientes.Where(x => x.Id == clienteInf.Id).First();
            clienteAlt.Cidade = clienteInf.Cidade;
            clienteAlt.Nome = clienteInf.Nome;
            clienteAlt.Email = clienteInf.Email;
            clienteAlt.Cpf = clienteInf.Cpf;
            clienteAlt.Cnpj = clienteInf.Cnpj;
            clienteAlt.Endereco = clienteInf.Endereco;
            clienteAlt.Telefone = clienteInf.Telefone;
            clienteAlt.Telefone2 = clienteInf.Telefone2;
            #endregion

            // Inserção de log de alteração de cliente
            Logs log = new Logs();
            log.Acao = acoesDAO.select(6);
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
            Clientes clienteExc = db.Clientes.Where(x => x.Id == id).First();
            clienteExc.Excluido = true;

            // Inserção de log de exclusão de cliente
            Logs log = new Logs();
            log.Acao = acoesDAO.select(7);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Clientes> select()
        {
            return db.Clientes.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
        }

        public Clientes select(int id)
        {
            // Selecionar cliente pelo ID, utilizado na parte de carregar os dados na alteração de cliente
            return db.Clientes.Include(x => x.Cidade).Where(x => x.Id == id).First();
        }
    }
}