using cecati_117.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cecati_117.Context
{
    public class Contexto_BaseDatos : DbContext
    {
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<InicioCarrusel> InicioCarrusel { get; set; }
        public virtual DbSet<RequisitosInscripcion> RequisitosInscripcion { get; set; }
        public virtual DbSet<ProximosCursos> ProximosCursos { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<Presentacion> Presentacion { get; set; }
        public virtual DbSet<ListaEspecialidades> ListaEspecialidades { get; set; }
        public virtual DbSet<EspecialidadDetalles> EspecialidadDetalles { get; set; }
        public virtual DbSet<Galeria> Galerias { get; set; }
        public virtual DbSet<Fotos_galeria> Fotos_Galerias { get; set; }
        public virtual DbSet<BolsaDeTrabajo> BolsaDeTrabajo { get; set; }
    }
}