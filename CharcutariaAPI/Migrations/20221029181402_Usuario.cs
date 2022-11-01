using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharcutariaAPI.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Usuarios(Nome,Email,Celular,CPF,FilialId)" +
                            "Values('Gabriel Nascimento','gabriel@gmail.com','(71)98888-8888','888.888.888-88',1)");

            migrationBuilder.Sql("Insert into Usuarios(Nome,Email,Celular,CPF,FilialId)" +
                           "Values('Julia Rabelo','julia@gmail.com','(71)99999-9999','777.777.777-77',2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Usuarios");
        }
    }
}
