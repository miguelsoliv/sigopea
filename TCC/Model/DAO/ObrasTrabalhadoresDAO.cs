using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;
using TCC.View;

namespace TCC.Model.DAO
{
    class ObrasTrabalhadoresDAO
    {
        private ModelDB db { get; set; }
        private Logs log;
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObrasTrabalhadoresDAO()
        {
            db = new ModelDB();
        }

        public void insert(ObrasTrabalhadores otInf)
        {
            #region Inclusão de trabalhador relacionado a obra x
            // "posiciona" no trabalhador/obra selecionado
            otInf.Trabalhador = db.Trabalhadores.ToList().Where(x => x.Id == otInf.Trabalhador.Id).First();
            otInf.Obra = db.Obras.ToList().Where(x => x.Id == otInf.Obra.Id).First();

            db.Trabalhadores.Attach(otInf.Trabalhador);
            db.Obras.Attach(otInf.Obra);
            db.ObrasTrabalhadores.Add(otInf);
            db.SaveChanges();
            #endregion

            #region Inserção de log de inclusão de obras_trabalhadores
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 23).First();
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

        public void delete(int idTrab, int idObra)
        {
            #region Exclusão da relação
            // posiciona no registro a ser excluído
            ObrasTrabalhadores otExc = db.ObrasTrabalhadores.Where(x => x.Trabalhador.Id == idTrab && x.Obra.Id == idObra).First();
            db.ObrasTrabalhadores.Remove(otExc);
            db.SaveChanges();
            #endregion

            #region Inserção de log de exclusão de obras_trabalhadores
            try
            {
                log = new Logs();
                log.Acao = acoesDAO.select().Where(x => x.Id == 24).First();
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

        public IEnumerable<ObrasTrabalhadores> select()
        {
            #region Lista de trabalhadores relacionados com as obras
            // Include "inclui" dados da tabela relacionada na listagem
            // Obs.: para usar o include deve ser adicionado nos using do cabeçalho:
            // using System.Data.Entity;
            return db.ObrasTrabalhadores.Include(x => x.Trabalhador).Include(x => x.Obra).ToList();
            #endregion
        }
    }
}