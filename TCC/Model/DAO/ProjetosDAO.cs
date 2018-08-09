using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class ProjetosDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ProjetosDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(Projetos projetoInf)
        {
            projetoInf.Cidade = db.Cidades.Where(x => x.Id == projetoInf.Cidade.Id).First();
            projetoInf.Cliente = db.Clientes.Where(x => x.Id == projetoInf.Cliente.Id).First();
            projetoInf.Status = db.Status.Where(x => x.Id == projetoInf.Status.Id).First();
            db.Projetos.Add(projetoInf);

            // Inserção de log de inclusão de projeto
            Logs log = new Logs();
            log.Acao = acoesDAO.select(17);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Projetos projetoInf)
        {
            #region Alteração de projeto
            projetoInf.Cidade = db.Cidades.Where(x => x.Id == projetoInf.Cidade.Id).First();
            projetoInf.Cliente = db.Clientes.Where(x => x.Id == projetoInf.Cliente.Id).First();
            projetoInf.Status = db.Status.Where(x => x.Id == projetoInf.Status.Id).First();
            // posiciona no registro a ser alterado
            Projetos projetoAlt = db.Projetos.Where(x => x.Id == projetoInf.Id).First();
            projetoAlt.Cidade = projetoInf.Cidade;
            projetoAlt.Cliente = projetoInf.Cliente;
            projetoAlt.DataFim = projetoInf.DataFim;
            projetoAlt.DataInicio = projetoInf.DataInicio;
            projetoAlt.Endereco = projetoInf.Endereco;
            projetoAlt.Excluido = projetoInf.Excluido;
            projetoAlt.PrazoEstipulado = projetoInf.PrazoEstipulado;
            projetoAlt.Preco = projetoInf.Preco;
            projetoAlt.Status = projetoInf.Status;
            #endregion

            // Inserção de log de alteração de projeto
            Logs log = new Logs();
            log.Acao = acoesDAO.select(18);
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
            Projetos projetoExc = db.Projetos.Where(x => x.Id == id).First();
            projetoExc.Excluido = true;

            // Inserção de log de exclusão de projeto
            Logs log = new Logs();
            log.Acao = acoesDAO.select(19);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Projetos> select()
        {
            return db.Projetos.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status)
                .Where(x => x.Excluido != true).ToList();
        }

        public Projetos select(int id)
        {
            // Selecionar projeto pelo ID, utilizado na parte de carregar os dados na alteração de projeto
            return db.Projetos.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Where(x => x.Id == id).First();
        }
    }
}