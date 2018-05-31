namespace TCC.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class tabelasNNDasPessoas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 5),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Descricao = c.String(unicode: false, storeType: "text"),
                        Obra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obras", t => t.Obra_Id)
                .Index(t => t.Obra_Id);
            
            CreateTable(
                "dbo.ObrasFornecedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacao = c.String(unicode: false, storeType: "text"),
                        Fornecedor_Id = c.Int(),
                        Obra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedores", t => t.Fornecedor_Id)
                .ForeignKey("dbo.Obras", t => t.Obra_Id)
                .Index(t => t.Fornecedor_Id)
                .Index(t => t.Obra_Id);
            
            CreateTable(
                "dbo.ObrasTrabalhadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Obra_Id = c.Int(),
                        Trabalhador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obras", t => t.Obra_Id)
                .ForeignKey("dbo.Trabalhadores", t => t.Trabalhador_Id)
                .Index(t => t.Obra_Id)
                .Index(t => t.Trabalhador_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ObrasTrabalhadores", "Trabalhador_Id", "dbo.Trabalhadores");
            DropForeignKey("dbo.ObrasTrabalhadores", "Obra_Id", "dbo.Obras");
            DropForeignKey("dbo.ObrasFornecedores", "Obra_Id", "dbo.Obras");
            DropForeignKey("dbo.ObrasFornecedores", "Fornecedor_Id", "dbo.Fornecedores");
            DropForeignKey("dbo.Fotos", "Obra_Id", "dbo.Obras");
            DropIndex("dbo.ObrasTrabalhadores", new[] { "Trabalhador_Id" });
            DropIndex("dbo.ObrasTrabalhadores", new[] { "Obra_Id" });
            DropIndex("dbo.ObrasFornecedores", new[] { "Obra_Id" });
            DropIndex("dbo.ObrasFornecedores", new[] { "Fornecedor_Id" });
            DropIndex("dbo.Fotos", new[] { "Obra_Id" });
            DropTable("dbo.ObrasTrabalhadores");
            DropTable("dbo.ObrasFornecedores");
            DropTable("dbo.Fotos");
        }
    }
}