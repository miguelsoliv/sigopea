namespace TCC.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class tabelasNNDosRegistros : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegCrea", "Id", "dbo.Projetos");
            DropIndex("dbo.RegCrea", new[] { "Id" });
            DropPrimaryKey("dbo.RegCrea");
            CreateTable(
                "dbo.RegCauProjeto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cau_Id = c.Int(),
                        Projeto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cau_Id)
                .Index(t => t.Projeto_Id);

            AddForeignKey("dbo.RegCauProjeto", "Cau_Id", "dbo.RegCau", "Id");
            AddForeignKey("dbo.RegCauProjeto", "Projeto_Id", "dbo.Projetos", "Id");

            CreateTable(
                "dbo.RegCreaProjeto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Crea_Id = c.Int(),
                        Projeto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Crea_Id)
                .Index(t => t.Projeto_Id);

            AddForeignKey("dbo.RegCreaProjeto", "Crea_Id", "dbo.RegCrea", "Id");
            AddForeignKey("dbo.RegCreaProjeto", "Projeto_Id", "dbo.Projetos", "Id");

            AlterColumn("dbo.RegCrea", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RegCrea", "Id");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegCauProjeto",
                c => new
                    {
                        Cau_Id = c.Int(nullable: false),
                        Projeto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cau_Id, t.Projeto_Id });
            
            DropForeignKey("dbo.RegCreaProjeto", "Projeto_Id", "dbo.Projetos");
            DropForeignKey("dbo.RegCreaProjeto", "Crea_Id", "dbo.RegCrea");
            DropForeignKey("dbo.RegCauProjeto", "Projeto_Id", "dbo.Projetos");
            DropForeignKey("dbo.RegCauProjeto", "Cau_Id", "dbo.RegCau");
            DropIndex("dbo.RegCreaProjeto", new[] { "Projeto_Id" });
            DropIndex("dbo.RegCreaProjeto", new[] { "Crea_Id" });
            DropIndex("dbo.RegCauProjeto", new[] { "Projeto_Id" });
            DropIndex("dbo.RegCauProjeto", new[] { "Cau_Id" });
            DropPrimaryKey("dbo.RegCrea");
            AlterColumn("dbo.RegCrea", "Id", c => c.Int(nullable: false));
            DropTable("dbo.RegCreaProjeto");
            DropTable("dbo.RegCauProjeto");
            AddPrimaryKey("dbo.RegCrea", "Id");
            CreateIndex("dbo.RegCauProjeto", "Projeto_Id");
            CreateIndex("dbo.RegCauProjeto", "Cau_Id");
            CreateIndex("dbo.RegCrea", "Id");
            AddForeignKey("dbo.RegCrea", "Id", "dbo.Projetos", "Id");
            AddForeignKey("dbo.RegCauProjeto", "Projeto_Id", "dbo.Projetos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RegCauProjeto", "Cau_Id", "dbo.RegCau", "Id", cascadeDelete: true);
        }
    }
}