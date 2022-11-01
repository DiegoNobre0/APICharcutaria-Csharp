using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharcutariaAPI.Migrations
{
    public partial class Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Clientes(Nome,Logradouro,Numero,Bairro,Cidade,Estado,CEP,Email,Celular,CPF,FilialId)" +
                            "Values('Diego Nobre','Caminho da Seresta',18,'Gleba E','Camaçari','Bahia','42808-151','diego@gmail.com','(71)98888-8888','222.222.222-22',1)");

            migrationBuilder.Sql("Insert into Clientes(Nome,Logradouro,Numero,Bairro,Cidade,Estado,CEP,Email,Celular,CPF,FilialId,Latitude,Logintude)" +
                            "Values('kamyla Silveira','Caminho da Primavera',10,'Gleba E','Camaçari','Bahia','42808-165','kamyla@gmail.com','(71)99999-9999','333.333.333-33',1)");

            migrationBuilder.Sql("Insert into Clientes(Nome,Logradouro,Numero,Bairro,Cidade,Estado,CEP,Email,Celular,CPF,FilialId,Latitude,Logintude)" +
                            "Values('Waleska Silveira','Rua Praia de Piatã',22,'Vilas do Atlântico','Lauro de Freitas','Bahia','42708-890','waleska@gmail.com','(71)97777-7777','444.444.444-44',2)");

            migrationBuilder.Sql("Insert into Clientes(Nome,Logradouro,Numero,Bairro,Cidade,Estado,CEP,Email,Celular,CPF,FilialId,Latitude,Logintude)" +
                            "Values('Junior Nascimento','Rua Praia de Jauá',35,'Vilas do Atlântico','Lauro de Freitas','Bahia','42708-870','junior@gmail.com','(71)96666-6666','555.555.555-55',2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Clientes");
        }
    }
}
