namespace MuseoRecord_v1.Migrations
{
    using MuseoRecord_v1.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MuseoRecord_v1.Models.MuseoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MuseoRecord_v1.Models.MuseoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var departamentos = new List<Departamento>
            {
                new Departamento { Nombre = "Dirección",        Estado = 1},
                new Departamento { Nombre = "Control de Obra",  Estado = 1},
                new Departamento { Nombre = "Curaduria",        Estado = 1},
                new Departamento { Nombre = "Restauración",     Estado = 1},
                new Departamento { Nombre = "Edecanes",         Estado = 1},
                new Departamento { Nombre = "Biblioteca",       Estado = 1},
                new Departamento { Nombre = "Seguridad",        Estado = 1},
                new Departamento { Nombre = "Acervo",           Estado = 1}
            };

            departamentos.ForEach(depa => context.Departamentos.AddOrUpdate(p => p.Nombre, depa));
            context.SaveChanges();
        }
    }
}
