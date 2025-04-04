using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categoria(Nome, ImagemUrl) VALUES ('Bebidas', 'https://www.linkparaimagem.com.br/bebidas.jpg')");
            mb.Sql("INSERT INTO Categoria(Nome, ImagemUrl) VALUES ('Lanches', 'https://www.linkparaimagem.com.br/lanches.jpg')");
            mb.Sql("INSERT INTO Categoria(Nome, ImagemUrl) VALUES ('Sobremesas', 'https://www.linkparaimagem.com.br/sobremesas.jpg')");
            mb.Sql("INSERT INTO Categoria(Nome, ImagemUrl) VALUES ('Saladas', 'https://www.linkparaimagem.com.br/saladas.jpg')");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categoria");

        }
    }
}
