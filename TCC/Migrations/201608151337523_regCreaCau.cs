namespace TCC.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class regCreaCau : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Assunto = c.String(maxLength: 45),
                        Observacao = c.String(unicode: false, storeType: "text"),
                        Obra_Id = c.Int(),
                        Projeto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obras", t => t.Obra_Id)
                .ForeignKey("dbo.Projetos", t => t.Projeto_Id)
                .Index(t => t.Obra_Id)
                .Index(t => t.Projeto_Id);
            
            CreateTable(
                "dbo.Obras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Endereco = c.String(maxLength: 100),
                        DataInicio = c.DateTime(nullable: false, storeType: "date"),
                        DataFim = c.DateTime(nullable: false, storeType: "date"),
                        PrazoEstipulado = c.DateTime(nullable: false, storeType: "date"),
                        Excluido = c.Boolean(nullable: false),
                        Cidade_Id = c.Int(),
                        Cliente_Id = c.Int(),
                        Responsavel_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.Cidade_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Responsavel", t => t.Responsavel_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Cidade_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Responsavel_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Estado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estados", t => t.Estado_Id)
                .Index(t => t.Estado_Id);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 20),
                        Sigla = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Senha = c.String(maxLength: 30),
                        Cpf = c.String(maxLength: 14),
                        Cnpj = c.String(maxLength: 18),
                        Endereco = c.String(maxLength: 100),
                        Telefone = c.String(maxLength: 25),
                        Telefone2 = c.String(maxLength: 25),
                        Excluido = c.Boolean(nullable: false),
                        Cidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.Cidade_Id)
                .Index(t => t.Cidade_Id);
            
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Telefone = c.String(maxLength: 25),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projetos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Endereco = c.String(maxLength: 100),
                        DataInicio = c.DateTime(nullable: false, storeType: "date"),
                        DataFim = c.DateTime(nullable: false, storeType: "date"),
                        PrazoEstipulado = c.DateTime(nullable: false, storeType: "date"),
                        Excluido = c.Boolean(nullable: false),
                        Cidade_Id = c.Int(),
                        Cliente_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.Cidade_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Cidade_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.RegCau",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Cau = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projetos", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RegCrea",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Crea = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projetos", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Fornecedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Cnpj = c.String(maxLength: 18),
                        Endereco = c.String(maxLength: 100),
                        Telefone = c.String(maxLength: 25),
                        Telefone2 = c.String(maxLength: 25),
                        Excluido = c.Boolean(nullable: false),
                        Cidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.Cidade_Id)
                .Index(t => t.Cidade_Id);
            
            CreateTable(
                "dbo.Observacoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Observacao = c.String(unicode: false, storeType: "text"),
                        Cliente_Id = c.Int(),
                        Fornecedor_Id = c.Int(),
                        Trabalhador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Fornecedores", t => t.Fornecedor_Id)
                .ForeignKey("dbo.Trabalhadores", t => t.Trabalhador_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Fornecedor_Id)
                .Index(t => t.Trabalhador_Id);
            
            CreateTable(
                "dbo.Trabalhadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Servico = c.String(maxLength: 25),
                        Cpf = c.String(maxLength: 14),
                        Endereco = c.String(maxLength: 100),
                        Telefone = c.String(maxLength: 25),
                        Telefone2 = c.String(maxLength: 25),
                        Excluido = c.Boolean(nullable: false),
                        Cidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.Cidade_Id)
                .Index(t => t.Cidade_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Login = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Senha = c.String(maxLength: 32),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Observacoes", "Trabalhador_Id", "dbo.Trabalhadores");
            DropForeignKey("dbo.Trabalhadores", "Cidade_Id", "dbo.Cidades");
            DropForeignKey("dbo.Observacoes", "Fornecedor_Id", "dbo.Fornecedores");
            DropForeignKey("dbo.Observacoes", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Fornecedores", "Cidade_Id", "dbo.Cidades");
            DropForeignKey("dbo.Agendamentos", "Projeto_Id", "dbo.Projetos");
            DropForeignKey("dbo.Projetos", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.RegCrea", "Id", "dbo.Projetos");
            DropForeignKey("dbo.Projetos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Projetos", "Cidade_Id", "dbo.Cidades");
            DropForeignKey("dbo.RegCau", "Id", "dbo.Projetos");
            DropForeignKey("dbo.Agendamentos", "Obra_Id", "dbo.Obras");
            DropForeignKey("dbo.Obras", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Obras", "Responsavel_Id", "dbo.Responsavel");
            DropForeignKey("dbo.Obras", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Cidade_Id", "dbo.Cidades");
            DropForeignKey("dbo.Obras", "Cidade_Id", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "Estado_Id", "dbo.Estados");
            DropIndex("dbo.Trabalhadores", new[] { "Cidade_Id" });
            DropIndex("dbo.Observacoes", new[] { "Trabalhador_Id" });
            DropIndex("dbo.Observacoes", new[] { "Fornecedor_Id" });
            DropIndex("dbo.Observacoes", new[] { "Cliente_Id" });
            DropIndex("dbo.Fornecedores", new[] { "Cidade_Id" });
            DropIndex("dbo.RegCrea", new[] { "Id" });
            DropIndex("dbo.RegCau", new[] { "Id" });
            DropIndex("dbo.Projetos", new[] { "Status_Id" });
            DropIndex("dbo.Projetos", new[] { "Cliente_Id" });
            DropIndex("dbo.Projetos", new[] { "Cidade_Id" });
            DropIndex("dbo.Clientes", new[] { "Cidade_Id" });
            DropIndex("dbo.Cidades", new[] { "Estado_Id" });
            DropIndex("dbo.Obras", new[] { "Status_Id" });
            DropIndex("dbo.Obras", new[] { "Responsavel_Id" });
            DropIndex("dbo.Obras", new[] { "Cliente_Id" });
            DropIndex("dbo.Obras", new[] { "Cidade_Id" });
            DropIndex("dbo.Agendamentos", new[] { "Projeto_Id" });
            DropIndex("dbo.Agendamentos", new[] { "Obra_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Trabalhadores");
            DropTable("dbo.Observacoes");
            DropTable("dbo.Fornecedores");
            DropTable("dbo.RegCrea");
            DropTable("dbo.RegCau");
            DropTable("dbo.Projetos");
            DropTable("dbo.Status");
            DropTable("dbo.Responsavel");
            DropTable("dbo.Clientes");
            DropTable("dbo.Estados");
            DropTable("dbo.Cidades");
            DropTable("dbo.Obras");
            DropTable("dbo.Agendamentos");
        }
    }
}