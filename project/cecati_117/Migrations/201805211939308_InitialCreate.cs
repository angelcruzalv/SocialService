namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InicioCarrusels",
                c => new
                    {
                        InicioCarrusel_ID = c.Guid(nullable: false),
                        InicioCarrusel_Titulo = c.String(),
                        InicioCarrusel_ImagenURL = c.String(),
                        InicioCarrusel_ListaAprendizaje = c.String(),
                    })
                .PrimaryKey(t => t.InicioCarrusel_ID);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        Noticias_ID = c.Guid(nullable: false),
                        Noticias_Titulo = c.String(),
                        Noticias_ImagenURL = c.String(),
                        Noticias_Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Noticias_ID);
            
            CreateTable(
                "dbo.Presentacions",
                c => new
                    {
                        Presentacion_ID = c.Guid(nullable: false),
                        Presentacion_titulo = c.String(),
                        Presentacion_descripcion = c.String(),
                        Presentacion_posicion = c.String(),
                    })
                .PrimaryKey(t => t.Presentacion_ID);
            
            CreateTable(
                "dbo.ProximosCursos",
                c => new
                    {
                        ProximosCursos_ID = c.Guid(nullable: false),
                        ProximosCursos_especialidad = c.String(),
                        ProximosCursos_ImagenURL = c.String(),
                    })
                .PrimaryKey(t => t.ProximosCursos_ID);
            
            CreateTable(
                "dbo.RequisitosInscripcions",
                c => new
                    {
                        RequisitosInscripcion_ID = c.Guid(nullable: false),
                        RequisitosInscripcion_titulo = c.String(),
                        RequisitosInscripcion_icono = c.String(),
                        RequisitosInscripcion_descripcion = c.String(),
                    })
                .PrimaryKey(t => t.RequisitosInscripcion_ID);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Servicios_ID = c.Guid(nullable: false),
                        Servicios_titulo = c.String(),
                        Servicios_descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Servicios_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Servicios");
            DropTable("dbo.RequisitosInscripcions");
            DropTable("dbo.ProximosCursos");
            DropTable("dbo.Presentacions");
            DropTable("dbo.Noticias");
            DropTable("dbo.InicioCarrusels");
        }
    }
}
