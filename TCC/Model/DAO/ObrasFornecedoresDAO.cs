using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class ObrasFornecedoresDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObrasFornecedoresDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insert(ObrasFornecedores ofInf)
        {
            ofInf.Fornecedor = db.Fornecedores.Where(x => x.Id == ofInf.Fornecedor.Id).First();
            ofInf.Obra = db.Obras.Where(x => x.Id == ofInf.Obra.Id).First();

            db.Fornecedores.Attach(ofInf.Fornecedor);
            db.Obras.Attach(ofInf.Obra);
            db.ObrasFornecedores.Add(ofInf);

            Logs log = new Logs();
            log.Acao = acoesDAO.select(25);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(ObrasFornecedores ofInf)
        {
            ObrasFornecedores ofAlt = db.ObrasFornecedores
                .Where(x => x.Fornecedor.Id == ofInf.Fornecedor.Id && x.Obra.Id == ofInf.Obra.Id).First();
            ofAlt.Observacao = ofInf.Observacao;

            Logs log = new Logs();
            log.Acao = acoesDAO.select(26);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void delete(int idForn, int idObra)
        {
            ObrasFornecedores ofExc = db.ObrasFornecedores.Where(x => x.Fornecedor.Id == idForn && x.Obra.Id == idObra).First();
            db.ObrasFornecedores.Remove(ofExc);

            Logs log = new Logs();
            log.Acao = acoesDAO.select(27);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<ObrasFornecedores> select()
        {
            return db.ObrasFornecedores.Include(x => x.Fornecedor).Include(x => x.Obra).ToList();
        }
    }
}