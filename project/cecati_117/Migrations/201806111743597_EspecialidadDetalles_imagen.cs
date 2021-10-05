namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EspecialidadDetalles_imagen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EspecialidadDetalles", "EspecialidadDetalles_Imagen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EspecialidadDetalles", "EspecialidadDetalles_Imagen");
        }
    }
}
