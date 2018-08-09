using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class ObrasDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObrasDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(Obras obraInf)
        {
            obraInf.Cidade = db.Cidades.Where(x => x.Id == obraInf.Cidade.Id).First();
            obraInf.Cliente = db.Clientes.Where(x => x.Id == obraInf.Cliente.Id).First();
            obraInf.Status = db.Status.Where(x => x.Id == obraInf.Status.Id).First();
            try
            {
                obraInf.Responsavel = db.Responsavel.Where(x => x.Id == obraInf.Responsavel.Id).First();
            }
            catch
            {

            }
            db.Obras.Add(obraInf);

            // Inserção de log de inclusão de obra
            Logs log = new Logs();
            log.Acao = acoesDAO.select(14);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Obras obraInf)
        {
            #region Alteração de obra
            obraInf.Cidade = db.Cidades.Where(x => x.Id == obraInf.Cidade.Id).First();
            obraInf.Cliente = db.Clientes.Where(x => x.Id == obraInf.Cliente.Id).First();
            obraInf.Status = db.Status.Where(x => x.Id == obraInf.Status.Id).First();
            try
            {
                obraInf.Responsavel = db.Responsavel.Where(x => x.Id == obraInf.Responsavel.Id).First();
            }
            catch
            {

            }
            // posiciona no registro a ser alterado
            Obras obraAlt = db.Obras.Where(x => x.Id == obraInf.Id).First();
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
            #endregion

            // Inserção de log de alteração de obra
            Logs log = new Logs();
            log.Acao = acoesDAO.select(15);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario()); ;

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void delete(int id)
        {
            Obras obraExc = db.Obras.Where(x => x.Id == id).First();
            obraExc.Excluido = true;

            // Inserção de log de exclusão de obra
            Logs log = new Logs();
            log.Acao = acoesDAO.select(16);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Obras> select()
        {
            return db.Obras.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Include(x => x.Responsavel)
                .Where(x => x.Excluido != true).ToList();
        }

        public Obras select(int id)
        {
            // Selecionar obra pelo ID, utilizado na parte de carregar os dados na alteração de obra
            return db.Obras.Include(x => x.Cidade).Include(x => x.Cliente).Include(x => x.Status).Include(x => x.Responsavel)
                .Where(x => x.Id == id).First();
        }
    }
}