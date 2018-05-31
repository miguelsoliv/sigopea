using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class TrabalhadoresDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public TrabalhadoresDAO()
        {
            db = new ModelDB();
        }

        public void insert(Trabalhadores trabalhadorInf)
        {
            #region Inclusão de trabalhador
            // "posiciona" na cidade selecionada
            trabalhadorInf.Cidade = db.Cidades.ToList().Where(x => x.Id == trabalhadorInf.Cidade.Id).First();
            db.Trabalhadores.Add(trabalhadorInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de trabalhador
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 8).First();
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

        public void update(Trabalhadores trabalhadorInf)
        {
            #region Alteração de trabalhador
            // "posiciona" na cidade selecionada
            trabalhadorInf.Cidade = db.Cidades.ToList().Where(x => x.Id == trabalhadorInf.Cidade.Id).First();
            // posiciona no registro a ser alterado
            Trabalhadores trabalhadorAlt = db.Trabalhadores.Where(x => x.Id == trabalhadorInf.Id).First();
            // altera suas propriedades
            trabalhadorAlt.Cidade = trabalhadorInf.Cidade;
            trabalhadorAlt.Nome = trabalhadorInf.Nome;
            trabalhadorAlt.Email = trabalhadorInf.Email;
            trabalhadorAlt.Cpf = trabalhadorInf.Cpf;
            trabalhadorAlt.Servico = trabalhadorInf.Servico;
            trabalhadorAlt.Endereco = trabalhadorInf.Endereco;
            trabalhadorAlt.Telefone = trabalhadorInf.Telefone;
            trabalhadorAlt.Telefone2 = trabalhadorInf.Telefone2;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de trabalhador
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 9).First();
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
            #region Exclusão de trabalhador
            // posiciona no registro a ser excluído
            Trabalhadores trabalhadorExc = db.Trabalhadores.Where(x => x.Id == id).First();
            trabalhadorExc.Excluido = true;
            //db.Trabalhadores.Remove(trabalhadorExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de trabalhador
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 10).First();
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

        public IEnumerable<Trabalhadores> select()
        {
            #region Lista de trabalhadores
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Trabalhadores.Include(x => x.Cidade).Where(x => x.Excluido != true).ToList();
            #endregion
        }

        public IEnumerable<Trabalhadores> select(int id)
        {
            #region Selecionar trabalhador pelo seu ID
            // Selecionar trabalhador pelo ID, utilizado na parte de carregar os dados na alteração de trabalhador
            return db.Trabalhadores.Include(x => x.Cidade).Where(x => x.Id == id).ToList();
            #endregion
        }
    }
}