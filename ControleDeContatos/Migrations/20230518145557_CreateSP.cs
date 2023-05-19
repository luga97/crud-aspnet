using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    public partial class CreateSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                CREATE PROCEDURE SaveClient
                	@Name VARCHAR(20),
                	@ImageBase64 VARCHAR(MAX),
                    @CPF VARCHAR(20)
                AS
                BEGIN
                	INSERT INTO dbo.Clients (Name, ImageBase64,CPF)
                	VALUES (@Name, @ImageBase64,@CPF)
                END
                ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = "DROP PROCEDURE SaveClient";
            migrationBuilder.Sql(sql);
        }
    }
}
