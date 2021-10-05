namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha_fotos_galeria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fotos_galeria", "Fotos_galeria_fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fotos_galeria", "Fotos_galeria_fecha");
        }
    }
}
