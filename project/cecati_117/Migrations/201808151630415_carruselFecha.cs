namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carruselFecha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InicioCarrusels", "InicioCarrusel_Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InicioCarrusels", "InicioCarrusel_Fecha");
        }
    }
}
