namespace TPINTEGRADOR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUsuarioTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CorreoElectronico = c.String(nullable: false, maxLength: 50, unicode: true),
                    Contrasenia = c.String(nullable: false),
                    //Persona = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            //.ForeignKey("dbo.Personas", t => t.Persona)
            //.Index(t => t.Persona);
        }

        public override void Down()
        {
            //DropForeignKey("dbo.Usuarios", "Persona", "dbo.Personas");
            DropTable("dbo.Usuarios");
        }
    }
}
