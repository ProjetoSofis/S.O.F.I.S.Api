# S.O.F.I.S.Api 🚀 
## Visão Geral
<p align="justify"> A S.O.F.I.S API é o backend centralizado, desenvolvido em ASP.NET Core, responsável por gerenciar dados e lógica de negócios para o sistema S.O.F.I.S.

Esta API utiliza o Entity Framework Core para persistência de dados em um banco de dados PostgreSQL, com configurações otimizadas para ambientes de desenvolvimento utilizando Docker. </p>

## 💻 Tecnologias Utilizadas
- Linguagem: C#

- Framework: ASP.NET Core 8+

- Banco de Dados: PostgreSQL

- ORM: Entity Framework Core (com Npgsql)

- Containerização: Docker

## 🛠️ Configuração e Instalação (Ambiente de Desenvolvimento)
Siga os passos abaixo para configurar e rodar a API localmente:

## Pré-requisitos
- SDK do .NET Core: Versão 8.0 ou superior.

- Docker Desktop: Necessário para rodar o banco de dados PostgreSQL.
### Passo 1: Subir o Banco de Dados PostgreSQL
```docker run --name postgre-development -e POSTGRES_PASSWORD=Password -p 5432:5432 -d postgres```

### Passo 2: Aplicar as Migrations do Banco de Dados
Navegue até o diretório raiz da sua Solution (Sofis.Api) e execute o comando para aplicar as migrations e criar o esquema do banco de dados:
```dotnet ef database update --project Sofis```

### Passo 3: Rodar a API
Execute a aplicação a partir do diretório raiz do projeto Sofis.Api:
```dotnet run --project Sofis.Api```

## 🔬 Testando a API
Após iniciar a aplicação, você pode testar os endpoints através da documentação do Swagger/OpenAPI.
Acessando o Swagger UI
Abra o navegador e acesse:
https://localhost:7221/swagger

## 📄 Licença
Este projeto está licenciado sob a Licença MIT.

### Desenvolvido por [Ágape LTDA.]
