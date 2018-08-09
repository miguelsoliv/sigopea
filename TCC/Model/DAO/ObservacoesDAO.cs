using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class ObservacoesDAO
    {
        private ModelDB db { get; set; }
        private AcoesDAO acoesDAO { get; set; }
        private UsuariosDAO usuariosDAO { get; set; }

        public ObservacoesDAO()
        {
            db = new ModelDB();
            acoesDAO = new AcoesDAO();
            usuariosDAO = new UsuariosDAO();
        }

        public void insertComCliente(Observacoes obsInf)
        {
            obsInf.Cliente = db.Clientes.Where(x => x.Id == obsInf.Cliente.Id).First();
            db.Observacoes.Add(obsInf);

            // Inserção de log de inserção de observação
            Logs log = new Logs();
            log.Acao = acoesDAO.select(20);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void insertComTrab(Observacoes obsInf)
        {
            obsInf.Trabalhador = db.Trabalhadores.Where(x => x.Id == obsInf.Trabalhador.Id).First();
            db.Observacoes.Add(obsInf);

            // Inserção de log de inserção de observação
            Logs log = new Logs();
            log.Acao = acoesDAO.select(20);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void insertComForn(Observacoes obsInf)
        {
            obsInf.Fornecedor = db.Fornecedores.Where(x => x.Id == obsInf.Fornecedor.Id).First();
            db.Observacoes.Add(obsInf);

            // Inserção de log de inserção de observação
            Logs log = new Logs();
            log.Acao = acoesDAO.select(20);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public void update(Observacoes obsInf)
        {
            Observacoes obsAlt = db.Observacoes.Where(x => x.Id == obsInf.Id).First();
            obsAlt.Observacao = obsInf.Observacao;

            // Inserção de log de alteração de observação
            Logs log = new Logs();
            log.Acao = acoesDAO.select(21);
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
            Observacoes observacaoExc = db.Observacoes.Where(x => x.Id == id).First();
            db.Observacoes.Remove(observacaoExc);

            // Inserção de log de exclusão de observação
            Logs log = new Logs();
            log.Acao = acoesDAO.select(22);
            log.Data = DateTime.Today.ToString("dd/MM/yyyy");
            log.Hora = DateTime.Now.ToString("HH:mm");
            log.Usuario = usuariosDAO.select(Variaveis.getIdUsuario());

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);

            db.SaveChanges();
        }

        public IEnumerable<Observacoes> select()
        {
            return db.Observacoes.Include(x => x.Cliente).Include(x => x.Trabalhador).Include(x => x.Fornecedor).ToList();
        }
    }
}