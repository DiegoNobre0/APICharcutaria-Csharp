using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharcutariaAPI.Migrations
{
    public partial class Filial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Filiais(Cidade,Estado,CEP,Logradouro,Numero,Bairro,CNPJ) " +
                "Values('Camaçari','Bahia','42804-487','Rua Duque de Caxias',309,'Centro','22.222.222/2222.22')");

            migrationBuilder.Sql("Insert into Filiais(Cidade,Estado,CEP,Logradouro,Numero,Bairro,CNPJ) " +
                "Values('Lauro de Freitas','Bahia','42700-000','Avenida Amarílio Thiago dos Santos',70,'Centro')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Filiais");
        }
    }
}
