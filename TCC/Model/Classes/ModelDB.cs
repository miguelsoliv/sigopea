namespace TCC.Model.Classes
{
    using System.Data.Entity;

    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<Acoes> Acoes { get; set; }
        public virtual DbSet<Agendamentos> Agendamentos { get; set; }
        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Fotos> Fotos { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Obras> Obras { get; set; }
        public virtual DbSet<ObrasFornecedores> ObrasFornecedores { get; set; }
        public virtual DbSet<ObrasTrabalhadores> ObrasTrabalhadores { get; set; }
        public virtual DbSet<Observacoes> Observacoes { get; set; }
        public virtual DbSet<PalavrasProibidas> PalavrasProibidas { get; set; }
        public virtual DbSet<Projetos> Projetos { get; set; }
        public virtual DbSet<RegCau> RegCau { get; set; }
        public virtual DbSet<RegCauProjeto> RegCauProjeto { get; set; }
        public virtual DbSet<RegCrea> RegCrea { get; set; }
        public virtual DbSet<RegCreaProjeto> RegCreaProjeto { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Trabalhadores> Trabalhadores { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}