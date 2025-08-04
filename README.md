
# ToDoList ASP.NET Core MVC

![Build](https://img.shields.io/badge/build-passing-brightgreen)
![Deploy](https://img.shields.io/badge/deploy-Railway-blueviolet)
![License](https://img.shields.io/badge/license-MIT-lightgrey)

Projeto de lista de tarefas (To Do List) desenvolvido em ASP.NET Core MVC, com Entity Framework Core e banco de dados PostgreSQL (Neon). Ideal para portfólio, estudos e validação de conhecimentos de desenvolvimento web com C#.

## Funcionalidades
- CRUD completo de tarefas (criar, listar, editar, excluir)
- Validação de formulários (DataAnnotations e Razor)
- Feedback visual ao usuário (TempData + Bootstrap)
- Persistência com Entity Framework Core
- Banco de dados PostgreSQL (Neon) ou SQLite
- Interface responsiva com Bootstrap
- Controle de versionamento com Git

## Tecnologias Utilizadas
- ASP.NET Core MVC
- C#
- Entity Framework Core
- PostgreSQL (Neon) / SQLite
- Bootstrap 5
- Razor Views
- Git

## Como rodar o projeto localmente
1. **Clone o repositório:**
   ```bash
   git clone https://github.com/nathan-marrero-petruci/ToDoList.git
   cd ToDoList
   ```
2. **Configure a connection string:**
   - Edite o arquivo `appsettings.json` com sua string do PostgreSQL (Neon) ou SQLite.
3. **Restaure os pacotes:**
   ```bash
   dotnet restore
   ```
4. **Aplique as migrations:**
   ```bash
   dotnet ef database update
   ```
5. **Execute o projeto:**
   ```bash
   dotnet run
   ```
6. **Acesse no navegador:**
   - http://localhost:5000 ou http://localhost:5001

## Estrutura do Projeto
- `Models/Task.cs`: Modelo de tarefa, validações e campos obrigatórios
- `Controllers/TasksController.cs`: CRUD de tarefas, feedbacks
- `Views/Tasks/`: Telas de CRUD, validação e feedback visual
- `appsettings.json`: Configuração do banco de dados
- `.gitignore`: Arquivos ignorados no versionamento

## Diferenciais
- Feedback visual para ações do usuário
- Validação de dados no backend e frontend
- Pronto para deploy em serviços como Railway, Azure, etc.
- Código limpo, comentado e organizado

## Deploy
Você pode fazer deploy facilmente em plataformas como Railway, Azure App Service, Heroku, etc. Basta configurar as variáveis de ambiente e connection string.

### Exemplo de configuração no Railway
1. Faça login em https://railway.app/ e conecte seu repositório.
2. Gere o domínio público em "Settings > Networking > Generate Domain".
3. Adicione a variável de ambiente:
   - **Key:** `ConnectionStrings__DefaultConnection`
   - **Value:** `Host=...;Port=5432;Database=...;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true`
4. (Opcional) Adicione `ASPNETCORE_URLS` com valor `http://0.0.0.0:8080`.
5. O Railway fará o build e deploy automaticamente.

## Como contribuir
Pull requests são bem-vindos! Sinta-se à vontade para sugerir melhorias, abrir issues ou propor novas funcionalidades.

## Licença
Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

---

> Projeto desenvolvido para fins de estudo, portfólio e validação de conhecimentos de desenvolvimento web com C# e ASP.NET Core MVC. Ideal para quem busca consolidar fundamentos de júnior e se preparar para desafios de pleno.

## Testes
Testes manuais realizados em todas as operações do CRUD. (Opcional: adicionar testes unitários com xUnit ou NUnit)

## Contribuição
Pull requests são bem-vindos! Sinta-se à vontade para sugerir melhorias ou abrir issues.

## Licença
Este projeto está sob a licença MIT.
