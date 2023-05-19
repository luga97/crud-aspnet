using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageBase64 { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string CPF { get; set; }
    }
}

/*
 *         protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"             
                CREATE PROCEDURE BuscarMarca
                	@NomeMarca VARCHAR(20)
                AS
                BEGIN
                	SET @NomeMarca = '%' + @NomeMarca + '%'

                	SELECT *
                	FROM dbo.Brands b
                	WHERE b.Name like @NomeMarca
                END
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE BuscarMarca");
        }
 * 
*/