namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime_noticias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Noticias", "Noticias_Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Noticias", "Noticias_Fecha");
        }
    }
}
