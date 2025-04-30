# 📦 WebAPI - Catálogo de Produtos

Este é um projeto de Web API desenvolvido com ASP.NET Core. A aplicação fornece endpoints com métodos assíncronos para o gerenciamento de produtos e categorias, com funcionalidades de listagem, 
criação, edição e remoção. Ideal para fins de aprendizado e como base para sistemas de e-commerce ou catálogos.

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core Web API
- Entity Framework Core
- MySQL (padrão) ou outro banco configurável
- Swagger (Swashbuckle)

## 📁 Estrutura do Projeto

```plaintext
├── Controllers/
│   ├── ProdutosController.cs
│   └── CategoriasController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── Produto.cs
│   └── Categoria.cs
├── Migrations/
├── appsettings.json
└── Program.cs
```

## ⚙️ Como Executar o Projeto

### Pré-requisitos

- .NET 8 SDK instalado
- Visual Studio, VS Code ou terminal
- MySQL (ou configure sua base no `appsettings.json`)

### Passos

```bash
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
```

A aplicação estará disponível em: `https://localhost:5001` ou `http://localhost:5000`

## 📓 Documentação da API

O Swagger está disponível para facilitar os testes dos endpoints:

```
https://localhost:5001/swagger
```

## 📌 Endpoints disponíveis

| Método  | Rota                         | Descrição                             |
|---------|------------------------------|----------------------------------------|
| GET     | /produtos                    | Lista todos os produtos               |
| GET     | /produtos/{id}               | Retorna um produto por ID             |
| POST    | /produtos                    | Cria um novo produto                  |
| PUT     | /produtos/{id}               | Atualiza um produto existente         |
| DELETE  | /produtos/{id}               | Remove um produto                     |
| GET     | /categorias                  | Lista todas as categorias             |
| GET     | /categorias/{id}             | Retorna uma categoria por ID          |
| GET     | /categorias/produtos         | Lista categorias com seus produtos    |

## 📂 Migrations

As migrations do EF Core estão salvas na pasta `Migrations/`.

Para criar uma nova migration:

```bash
dotnet ef migrations add NomeDaMigration
```

## 🛑 Observações

- As configurações de conexão estão em `appsettings.json`. Evite incluir dados sensíveis diretamente no arquivo — prefira variáveis de ambiente em produção.
- A string de conexão está configurada para SQLite, mas pode ser facilmente adaptada para SQL Server ou outro banco.

Feito por [Matheus Veiga](https://www.linkedin.com/in/matheus-veiga-011566158/)