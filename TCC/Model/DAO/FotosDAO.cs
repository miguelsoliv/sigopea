using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class FotosDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public FotosDAO()
        {
            db = new ModelDB();
        }

        public void insert(Fotos fotoInf)
        {
            fotoInf.Obra = db.Obras.Where(x => x.Id == fotoInf.Obra.Id).First();
            db.Fotos.Add(fotoInf);

            // Inserção de log de inclusão de foto
            Logs log = new Logs();
            log.Acao = acoesDAO.select(31);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Fotos fotoInf)
        {
            Fotos fotoAlt = db.Fotos.Where(x => x.Id == fotoInf.Id).First();
            fotoAlt.Descricao = fotoInf.Descricao;

            // Inserção de log de alteração de foto
            Logs log = new Logs();
            log.Acao = acoesDAO.select(32);
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
            Fotos fotoExc = db.Fotos.Where(x => x.Id == id).First();
            db.Fotos.Remove(fotoExc);

            // Inserção de log de exclusão de foto
            Logs log = new Logs();
            log.Acao = acoesDAO.select(33);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Fotos> select()
        {
            return db.Fotos.Include(x => x.Obra).ToList();
        }
    }
}