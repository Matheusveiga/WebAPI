using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('Coca-Cola', 'Refrigerante de Cola', 5.50, 'https://www.linkparaimagem.com.br/coca-cola.jpg',100,now(), 1)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('X-Burguer', 'Sanduíche com carne e queijo', 15.00, 'https://www.linkparaimagem.com.br/x-burguer.jpg',50,now(),2)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('Pudim', 'Sobremesa de leite condensado', 8.00, 'https://www.linkparaimagem.com.br/pudim.jpg',30,now(),3)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('Salada Caesar', 'Salada com frango grelhado e molho Caesar', 12.00, 'https://www.linkparaimagem.com.br/salada-caesar.jpg',20,now(),4)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('Fanta Laranja', 'Refrigerante de Laranja', 5.50, 'https://www.linkparaimagem.com.br/fanta-laranja.jpg',100,now(),1)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('X-Salada', 'Sanduíche com carne, queijo e salada', 16.00, 'https://www.linkparaimagem.com.br/x-salada.jpg',50,now(),2)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('Torta de Limão', 'Sobremesa de limão', 9.00, 'https://www.linkparaimagem.com.br/torta-limao.jpg',30,now(),3)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('Salada de Frutas', 'Salada com frutas variadas', 10.00, 'https://www.linkparaimagem.com.br/salada-frutas.jpg',20,now(),4)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('Guaraná', 'Refrigerante de Guaraná', 5.50, 'https://www.linkparaimagem.com.br/guarana.jpg',100,now(),1)");
            mb.Sql("INSERT INTO Produto(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) VALUES ('X-Tudo', 'Sanduíche com carne, queijo e tudo mais', 18.00, 'https://www.linkparaimagem.com.br/x-tudo.jpg',50,now(),2)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produto");

        }
    }
}
