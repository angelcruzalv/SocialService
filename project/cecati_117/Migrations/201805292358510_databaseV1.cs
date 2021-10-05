namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EspecialidadDetalles",
                c => new
                    {
                        EspecialidadDetalles_ID = c.Guid(nullable: false),
                        EspecialidadDetalles_titulo = c.String(),
                        EspecialidadDetalles_descripcion = c.String(),
                        EspecialidadDetalles_ListaAprendizaje = c.String(),
                        Id_Especialidad_ListaEspecialidades_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.EspecialidadDetalles_ID)
                .ForeignKey("dbo.ListaEspecialidades", t => t.Id_Especialidad_ListaEspecialidades_ID)
                .Index(t => t.Id_Especialidad_ListaEspecialidades_ID);
            
            CreateTable(
                "dbo.ListaEspecialidades",
                c => new
                    {
                        ListaEspecialidades_ID = c.Guid(nullable: false),
                        ListaEspecialidades_especialidad = c.String(),
                    })
                .PrimaryKey(t => t.ListaEspecialidades_ID);
            
            CreateTable(
                "dbo.ImagenDeGalerias",
                c => new
                    {
                        ImagenDeGaleria_ID = c.Guid(nullable: false),
                        ImagenDeGaleria_titulo = c.String(),
                        ImagenDeGaleria_Autor = c.String(),
                        ImagenDeGaleria_imagenURL = c.String(),
                        Id_Especialidad_ListaEspecialidades_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ImagenDeGaleria_ID)
                .ForeignKey("dbo.ListaEspecialidades", t => t.Id_Especialidad_ListaEspecialidades_ID)
                .Index(t => t.Id_Especialidad_ListaEspecialidades_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagenDeGalerias", "Id_Especialidad_ListaEspecialidades_ID", "dbo.ListaEspecialidades");
            DropForeignKey("dbo.EspecialidadDetalles", "Id_Especialidad_ListaEspecialidades_ID", "dbo.ListaEspecialidades");
            DropIndex("dbo.ImagenDeGalerias", new[] { "Id_Especialidad_ListaEspecialidades_ID" });
            DropIndex("dbo.EspecialidadDetalles", new[] { "Id_Especialidad_ListaEspecialidades_ID" });
            DropTable("dbo.ImagenDeGalerias");
            DropTable("dbo.ListaEspecialidades");
            DropTable("dbo.EspecialidadDetalles");
        }
    }
}
