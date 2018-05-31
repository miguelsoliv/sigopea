namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaoDeLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 35),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Hora = c.Time(nullable: false, precision: 7),
                        Acao_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Acoes", t => t.Acao_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Acao_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Logs", "Acao_Id", "dbo.Acoes");
            DropIndex("dbo.Logs", new[] { "Usuario_Id" });
            DropIndex("dbo.Logs", new[] { "Acao_Id" });
            DropTable("dbo.Logs");
            DropTable("dbo.Acoes");
        }
    }
}
