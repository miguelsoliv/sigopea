using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class ObrasDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObrasDAO()
        {
            db = new ModelDB();
        }

        public void insert(Obras obraInf)
        {
            #region Inclusão de obra
            // "posiciona" na cidade/cliente/responsavel/status selecionados
            obraInf.Cidade = db.Cidades.ToList().Where(x => x.Id == obraInf.Cidade.Id).First();
            obraInf.Cliente = db.Clientes.ToList().Where(x => x.Id == obraInf.Cliente.Id).First();
            obraInf.Status = db.Status.ToList().Where(x => x.Id == obraInf.Status.Id).First();
            try
            {
                obraInf.Responsavel = db.Responsavel.ToList().Where(x => x.Id == obraInf.Responsavel.Id).First();
            }
            catch
            {

            }
            db.Obras.Add(obraInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de obra
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 14).First();
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

        public void update(Obras obraInf)
        {
            #region Alteração de obra
            // "posiciona" na cidade/cliente/responsavel/status selecionados
            obraInf.Cidade = db.Cidades.ToList().Where(x => x.Id == obraInf.Cidade.Id).First();
            obraInf.Cliente = db.Clientes.ToList().Where(x => x.Id == obraInf.Cliente.Id).First();
            obraInf.Status = db.Status.ToList().Where(x => x.Id == obraInf.Status.Id).First();
            try
            {
                obraInf.Responsavel = db.Responsavel.ToList().Where(x => x.Id == obraInf.Responsavel.Id).First();
            }
            catch
            {

            }
            // posiciona no registro a ser alterado
            Obras obraAlt = db.Obras.Where(x => x.Id == obraInf.Id).First();
            // altera suas propriedades
            obraAlt.Cidade = obraInf.Cidade;
            obraAlt.Cliente = obraInf.Cliente;
            obraAlt.DataFim = obraInf.DataFim;
            obraAlt.DataInicio = obraInf.DataInicio;
            obraAlt.Endereco = obraInf.Endereco;
            obraAlt.Excluido = obraInf.Excluido;
            obraAlt.PrazoEstipulado = obraInf.PrazoEstipulado;
            obraAlt.Preco = obraInf.Preco;
            obraAlt.Responsavel = obraInf.Responsavel;
            obraAlt.Status = obraInf.Status;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de obra
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 15).First();
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
            #region Exclusão de obra
            // posiciona no registro a ser excluído
            Obras obraExc = db.Obras.Where(x => x.Id == id).First();
            obraExc.Excluido = true;
            //db.Obras.Remove(obraExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de obra
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 16).First();
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

        public IEnumerable<Obras> select()
        {
            #region Lista de obras
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Obras.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Include(x => x.Responsavel).Where(x => x.Excluido != true).ToList();
            #endregion
        }

        public IEnumerable<Obras> select(int id)
        {
            #region Selecionar obra pelo seu ID
            // Selecionar obra pelo ID, utilizado na parte de carregar os dados na alteração de obra
            return db.Obras.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Include(x => x.Responsavel).ToList().Where(x => x.Id == id);
            #endregion
        }
    }
}