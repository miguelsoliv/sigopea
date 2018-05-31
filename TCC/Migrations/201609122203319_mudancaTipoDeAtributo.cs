namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudancaTipoDeAtributo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logs", "Hora", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logs", "Hora", c => c.Time(nullable: false, precision: 7));
        }
    }
}
