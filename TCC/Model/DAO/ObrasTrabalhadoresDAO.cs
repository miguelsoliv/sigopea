using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class ObrasTrabalhadoresDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObrasTrabalhadoresDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(ObrasTrabalhadores otInf)
        {
            otInf.Trabalhador = db.Trabalhadores.Where(x => x.Id == otInf.Trabalhador.Id).First();
            otInf.Obra = db.Obras.Where(x => x.Id == otInf.Obra.Id).First();

            db.Trabalhadores.Attach(otInf.Trabalhador);
            db.Obras.Attach(otInf.Obra);
            db.ObrasTrabalhadores.Add(otInf);

            Logs log = new Logs();
            log.Acao = acoesDAO.select(23);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void delete(int idTrab, int idObra)
        {
            ObrasTrabalhadores otExc = db.ObrasTrabalhadores.Where(x => x.Trabalhador.Id == idTrab && x.Obra.Id == idObra).First();
            db.ObrasTrabalhadores.Remove(otExc);

            Logs log = new Logs();
            log.Acao = acoesDAO.select(24);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<ObrasTrabalhadores> select()
        {
            return db.ObrasTrabalhadores.Include(x => x.Trabalhador).Include(x => x.Obra).ToList();
        }
    }
}