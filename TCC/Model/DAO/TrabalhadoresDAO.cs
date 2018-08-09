using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class TrabalhadoresDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public TrabalhadoresDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(Trabalhadores trabalhadorInf)
        {
            trabalhadorInf.Cidade = db.Cidades.Where(x => x.Id == trabalhadorInf.Cidade.Id).First();
            db.Trabalhadores.Add(trabalhadorInf);

            // Inserção de log de inclusão de trabalhador
            Logs log = new Logs();
            log.Acao = acoesDAO.select(8);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Trabalhadores trabalhadorInf)
        {
            #region Alteração de trabalhador
            trabalhadorInf.Cidade = db.Cidades.Where(x => x.Id == trabalhadorInf.Cidade.Id).First();
            // posiciona no registro a ser alterado
            Trabalhadores trabalhadorAlt = db.Trabalhadores.Where(x => x.Id == trabalhadorInf.Id).First();
            trabalhadorAlt.Cidade = trabalhadorInf.Cidade;
            trabalhadorAlt.Nome = trabalhadorInf.Nome;
            trabalhadorAlt.Email = trabalhadorInf.Email;
            trabalhadorAlt.Cpf = trabalhadorInf.Cpf;
            trabalhadorAlt.Servico = trabalhadorInf.Servico;
            trabalhadorAlt.Endereco = trabalhadorInf.Endereco;
            trabalhadorAlt.Telefone = trabalhadorInf.Telefone;
            trabalhadorAlt.Telefone2 = trabalhadorInf.Telefone2;
            #endregion

            // Inserção de log de alteração de trabalhador
            Logs log = new Logs();
            log.Acao = acoesDAO.select(9);
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
            Trabalhadores trabalhadorExc = db.Trabalhadores.Where(x => x.Id == id).First();
            trabalhadorExc.Excluido = true;

            // Inserção de log de exclusão de trabalhador
            Logs log = new Logs();
            log.Acao = acoesDAO.select(10);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Trabalhadores> select()
        {
            return db.Trabalhadores.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
        }

        public Trabalhadores select(int id)
        {
            // Selecionar trabalhador pelo ID, utilizado na parte de carregar os dados na alteração de trabalhador
            return db.Trabalhadores.Include(x => x.Cidade).Where(x => x.Id == id).First();
        }
    }
}