namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numberOfTimeline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presentacions", "Presentacion_numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presentacions", "Presentacion_numero");
        }
    }
}
