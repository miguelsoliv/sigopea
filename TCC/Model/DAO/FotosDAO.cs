using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class FotosDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public FotosDAO()
        {
            db = new ModelDB();
        }

        public void insert(Fotos fotoInf)
        {
            #region Inclusão de foto
            // "posiciona" na obra selecionada
            fotoInf.Obra = db.Obras.ToList().Where(x => x.Id == fotoInf.Obra.Id).First();
            db.Fotos.Add(fotoInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de foto
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 31).First();
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

        public void update(Fotos fotoInf)
        {
            #region Alteração de foto
            // posiciona no registro a ser alterado
            Fotos fotoAlt = db.Fotos.Where(x => x.Id == fotoInf.Id).First();
            // altera suas propriedades
            fotoAlt.Descricao = fotoInf.Descricao;
            // salva o registro alterado
            db.SaveChanges();
            #endregion

            #region Inserção de log de alteração de foto
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 32).First();
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
            #region Exclusão de foto
            // posiciona no registro a ser excluído
            Fotos fotoExc = db.Fotos.Where(x => x.Id == id).First();
            db.Fotos.Remove(fotoExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de foto
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 33).First();
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

        public IEnumerable<Fotos> select()
        {
            #region Lista de fotos
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.Fotos.Include(x => x.Obra).ToList();
            #endregion
        }
    }
}