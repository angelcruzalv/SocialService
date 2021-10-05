namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bolsaTrabajo_agregada : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BolsaDeTrabajoes",
                c => new
                    {
                        BolsaDeTrabajo_ID = c.Guid(nullable: false),
                        BolsaDeTrabajo_Titulo = c.String(),
                        BolsaDeTrabajo_Descripción = c.String(),
                    })
                .PrimaryKey(t => t.BolsaDeTrabajo_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BolsaDeTrabajoes");
        }
    }
}
