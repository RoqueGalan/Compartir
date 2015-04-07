namespace MuseoRecord_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        DepartamentoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoID);
            
            CreateTable(
                "dbo.Puestoes",
                c => new
                    {
                        PuestoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Int(nullable: false),
                        DepartamentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PuestoID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Correo = c.String(),
                        Contrasena = c.String(),
                        Estado = c.Int(nullable: false),
                        PuestoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Puestoes", t => t.PuestoID, cascadeDelete: true)
                .Index(t => t.PuestoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "PuestoID", "dbo.Puestoes");
            DropIndex("dbo.Usuarios", new[] { "PuestoID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Puestoes");
            DropTable("dbo.Departamentoes");
        }
    }
}
