namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracoesFinais : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Senha", c => c.String(maxLength: 32));
            AlterColumn("dbo.Observacoes", "Data", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.PalavrasProibidas", "Palavra", c => c.String(maxLength: 25));
            AlterColumn("dbo.RegCau", "Cau", c => c.String(maxLength: 8));
            AlterColumn("dbo.RegCrea", "Crea", c => c.String(maxLength: 8));
            RenameTable(name: "dbo.RegCrea", newName: "RegCreas");
            RenameTable(name: "dbo.RegCau", newName: "RegCaus");
            RenameTable(name: "dbo.RegCreaProjeto", newName: "RegCreaProjetoes");
            RenameTable(name: "dbo.RegCauProjeto", newName: "RegCauProjetoes");
            RenameTable(name: "dbo.Responsavel", newName: "Responsavels");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegCrea", "Crea", c => c.String(maxLength: 10));
            AlterColumn("dbo.RegCau", "Cau", c => c.String(maxLength: 10));
            AlterColumn("dbo.PalavrasProibidas", "Palavra", c => c.String(maxLength: 35));
            AlterColumn("dbo.Observacoes", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clientes", "Senha", c => c.String(maxLength: 30));
            RenameTable(name: "dbo.RegCreas", newName: "RegCrea");
            RenameTable(name: "dbo.RegCaus", newName: "RegCau");
            RenameTable(name: "dbo.RegCreaProjetoes", newName: "RegCreaProjeto");
            RenameTable(name: "dbo.RegCauProjetoes", newName: "RegCauProjeto");
            RenameTable(name: "dbo.Responsavels", newName: "Responsavel");
        }
    }
}
