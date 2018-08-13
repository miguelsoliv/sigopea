using System.Collections.Generic;
using System.Linq;
using TCC.Model.Classes;
using System.Data.Entity;
using System;

namespace TCC.Model.DAO
{
    class LogsDAO
    {
        private ModelDB db { get; set; }

        public LogsDAO()
        {
            db = new ModelDB();
        }

        public void insert(int acao)
        {
            int idUsuario = Variaveis.getIdUsuario();
            Logs log = new Logs();
            log.Acao = db.Acoes.Where(x => x.Id == acao).First();
            log.Data = DateTime.Now;
            log.Usuario = db.Usuarios.Where(x => x.Id == idUsuario).First();

            db.Acoes.Attach(log.Acao);
            db.Usuarios.Attach(log.Usuario);
            db.Logs.Add(log);
            db.SaveChanges();
        }

        public IEnumerable<Logs> select()
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).ToList();
        }

        // Métodos para pesquisa de logs no LogsAdmin
        public IEnumerable<Logs> selectTudo(string usuario, string acao, DateTime data)
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).Where(x => x.Usuario.Login.ToUpper().Contains(usuario.Trim().ToUpper()) && x.Acao.Descricao.ToUpper().Contains(acao.Trim().ToUpper()) && x.Data <= data).ToList();
        }

        public IEnumerable<Logs> selectUsuarioAcao(string usuario, string acao)
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).Where(x => x.Usuario.Login.ToUpper().Contains(usuario.Trim().ToUpper()) && x.Acao.Descricao.ToUpper().Contains(acao.Trim().ToUpper())).ToList();
        }

        public IEnumerable<Logs> selectUsuarioData(string usuario, DateTime data)
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).Where(x => x.Usuario.Login.ToUpper().Contains(usuario.Trim().ToUpper()) && x.Data <= data).ToList();
        }

        public IEnumerable<Logs> selectAcaoData(string acao, DateTime data)
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).Where(x =>x.Acao.Descricao.ToUpper().Contains(acao.Trim().ToUpper()) && x.Data <= data).ToList();
        }

        public IEnumerable<Logs> selectUsuario(string usuario)
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).Where(x => x.Usuario.Login.ToUpper().Contains(usuario.Trim().ToUpper())).ToList();
        }

        public IEnumerable<Logs> selectAcao(string acao)
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).Where(x => x.Acao.Descricao.ToUpper().Contains(acao.Trim().ToUpper())).ToList();
        }

        public IEnumerable<Logs> selectData(DateTime data)
        {
            return db.Logs.Include(x => x.Acao).Include(x => x.Usuario).Where(x => x.Data <= data).ToList();
        }

        // Verificar se o usuário já logou ao menos 1 vez no sistema. Mostrar mensagem de boas-vindas ao primeiro login feito.
        // Mostrar data do último login para os demais logins realizados
        public Logs usuarioJaLogou()
        {
            try
            {
                int id = Variaveis.getIdUsuario();
                return db.Logs.Include(x => x.Usuario).Where(x => x.Usuario.Id == id).ToList().Last();
            }
            catch
            {
                return null;
            }
        }
    }
}