namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudancaTipoDeAtributo2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logs", "Data", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logs", "Data", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
