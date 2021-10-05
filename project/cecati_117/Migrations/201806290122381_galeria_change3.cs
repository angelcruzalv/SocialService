namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class galeria_change3 : DbMigration
    {
        public override void Up()
        {                     
            CreateTable(
                "dbo.Fotos_galeria",
                c => new
                    {
                        Fotos_galeriaID = c.Guid(nullable: false),
                        Fotos_galeria_titulo = c.String(),
                        Fotos_galeria_autor = c.String(),
                        Fotos_galeria_imagenURL = c.String(),
                        Id_Galeria_Galeria_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Fotos_galeriaID)
                .ForeignKey("dbo.Galerias", t => t.Id_Galeria_Galeria_ID)
                .Index(t => t.Id_Galeria_Galeria_ID);
            
        }
        
        public override void Down()
        {                    
            DropForeignKey("dbo.Fotos_galeria", "Id_Galeria_Galeria_ID", "dbo.Galerias");
            DropIndex("dbo.Fotos_galeria", new[] { "Id_Galeria_Galeria_ID" });
            DropTable("dbo.Fotos_galeria");         
        }
    }
}
