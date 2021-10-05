namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicioCarrusel_imagen2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InicioCarrusels", "InicioCarrusel_MiniImagenUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InicioCarrusels", "InicioCarrusel_MiniImagenUrl");
        }
    }
}
