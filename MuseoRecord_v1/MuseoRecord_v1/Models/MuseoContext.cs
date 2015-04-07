using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MuseoRecord_v1.Models
{
    public class MuseoContext : DbContext
    {
        public MuseoContext()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Estructura> Estructuras { get; set; }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Pieza> Piezas { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<TipoAdquisicion> TiposAdquisiciones { get; set; }
        public DbSet<TipoAtributo> TiposAtributos { get; set; }
        public DbSet<TipoObra> TiposObras { get; set; }
        public DbSet<TipoPermiso> TiposPermisos { get; set; }
        public DbSet<TipoPieza> TiposPiezas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Obra>().
            HasMany(p => p.Piezas).
            WithRequired(p => p.Obra).
            WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPieza>().
            HasMany(p => p.Piezas).
            WithRequired(p => p.TipoPieza).
            WillCascadeOnDelete(false);
        }

    }
}