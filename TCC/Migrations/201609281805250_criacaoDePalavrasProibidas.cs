namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaoDePalavrasProibidas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PalavrasProibidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Palavra = c.String(maxLength: 35),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PalavrasProibidas");
        }
    }
}
