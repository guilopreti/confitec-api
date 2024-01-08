# ConfitecAPI

API feita com .NET, onde foi elaborado um CRUD simples de usuários.

## Iniciando o projeto

Faça um clone do repositório, navegue até o diretório do projeto e execute no terminal o comando `dotnet restore` para restaurar as dependências do projeto. 
Execute `dotnet run` para iniciar a aplicação, que estará disponível em `http://localhost:5018/`. 

Certifique-se de criar um banco de dados SQL Server antes de executar a API. Adicione um arquivo `.env` à aplicação e preencha-o seguindo o exemplo fornecido em `.env.example`.
Por fim, execute o comando `dotnet ef database update` no seu terminal para aplicar as migrações ao banco de dados recém-criado. Isso garantirá o funcionamento correto da aplicação.
