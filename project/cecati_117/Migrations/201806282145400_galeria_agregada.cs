namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class galeria_agregada : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ImagenDeGalerias", name: "Id_Especialidad_ListaEspecialidades_ID", newName: "ListaEspecialidades_ListaEspecialidades_ID");
            RenameIndex(table: "dbo.ImagenDeGalerias", name: "IX_Id_Especialidad_ListaEspecialidades_ID", newName: "IX_ListaEspecialidades_ListaEspecialidades_ID");
            CreateTable(
                "dbo.Galerias",
                c => new
                    {
                        Galeria_ID = c.Guid(nullable: false),
                        Galeria_titulo = c.String(),
                    })
                .PrimaryKey(t => t.Galeria_ID);
            
            AddColumn("dbo.ImagenDeGalerias", "Id_Galeria_Galeria_ID", c => c.Guid());
            CreateIndex("dbo.ImagenDeGalerias", "Id_Galeria_Galeria_ID");
            AddForeignKey("dbo.ImagenDeGalerias", "Id_Galeria_Galeria_ID", "dbo.Galerias", "Galeria_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagenDeGalerias", "Id_Galeria_Galeria_ID", "dbo.Galerias");
            DropIndex("dbo.ImagenDeGalerias", new[] { "Id_Galeria_Galeria_ID" });
            DropColumn("dbo.ImagenDeGalerias", "Id_Galeria_Galeria_ID");
            DropTable("dbo.Galerias");
            RenameIndex(table: "dbo.ImagenDeGalerias", name: "IX_ListaEspecialidades_ListaEspecialidades_ID", newName: "IX_Id_Especialidad_ListaEspecialidades_ID");
            RenameColumn(table: "dbo.ImagenDeGalerias", name: "ListaEspecialidades_ListaEspecialidades_ID", newName: "Id_Especialidad_ListaEspecialidades_ID");
        }
    }
}
