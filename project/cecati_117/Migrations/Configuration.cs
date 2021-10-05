namespace cecati_117.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using cecati_117.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<cecati_117.Context.Contexto_BaseDatos>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "cecati_117.Context.Contexto_BaseDatos";
        }

        protected override void Seed(cecati_117.Context.Contexto_BaseDatos context)
        {
            //  This method will be called after migrating to the latest version.                                

        }
    }
}
