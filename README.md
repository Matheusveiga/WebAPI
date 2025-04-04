# 📦 WebAPI - Catálogo de Produtos

Este é um projeto de Web API desenvolvido com ASP.NET Core. A aplicação fornece endpoints para o gerenciamento de produtos, com funcionalidades de listagem, 
criação, edição e remoção. Ideal para fins de aprendizado e base para sistemas de e-commerce ou catálogos.

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (LocalDB)
- Swagger (Swashbuckle)

## 📁 Estrutura do Projeto

```plaintext
├── Controllers/
│   └── ProdutosController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   └── Produto.cs
├── Migrations/
├── appsettings.json
└── Program.cs

⚙️ Como Executar o Projeto
Pré-requisitos

   - .NET 8 SDK

   - SQL Server LocalDB ou outra instância configurada

   - Visual Studio ou VS Code

Passos

# Clone o repositório
git clone https://github.com/Matheusveiga/WebAPI.git

# Acesse a pasta do projeto
cd WebAPI

# Restaure os pacotes
dotnet restore

# Aplique as migrations e crie o banco de dados
dotnet ef database update

# Execute a aplicação
dotnet run

A aplicação estará disponível em: http://localhost:5155

📓 Documentação da API

O Swagger está disponível para facilitar os testes dos endpoints:

http://localhost:5155/swagger

📌 Endpoints disponíveis

Método	          Rota	               Descrição

GET	         /produtos	      Lista todos os produtos
GET	         /produtos/{id}	      Retorna um produto por ID
POST	         /produtos	      Cria um novo produto
PUT	         /produtos/{id}	      Atualiza um produto existente
DELETE	         /produtos/{id}	      Remove um produto


📂 Migrations

As migrations do EF Core estão salvas na pasta Migrations/.

- Para criar uma nova migration:

dotnet ef migrations add NomeDaMigration

🛑 Observações

    Os arquivos appsettings.json e appsettings.Development.json não devem conter dados sensíveis como connection strings com usuário/senha. Utilize variáveis de ambiente em produção.

    A conexão atual está configurada para SQL Server LocalDB. Você pode alterar a string de conexão em appsettings.json.

📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

Feito por Matheus Veiga
