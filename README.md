# CleanArchitecture Example

## Sumário
- [Sobre o Projeto](#sobre-o-projeto)
- [Motivação](#motivação)
- [Arquitetura Utilizada](#arquitetura-utilizada)
- [Estrutura da Solução](#estrutura-da-solução)
- [Descrição das Camadas e Responsabilidades](#descrição-das-camadas-e-responsabilidades)
  - [CleanArchitecture.Domain](#cleanarchitecturedomain)
  - [CleanArchitecture.Application](#cleanarchitectureapplication)
  - [CleanArchitecture.Infrastructure.Data](#cleanarchitectureinfrastructuredata)
  - [CleanArchitecture.Infrastructure.IoC](#cleanarchitectureinfrastructureioc)
  - [CleanArchitecture.WebUI](#cleanarchitecturewebui)
- [Regras de Negócio](#regras-de-negócio)
  - [Produto](#produto)
  - [Categoria](#categoria)
- [Nomenclatura e Convenções](#nomenclatura-e-convenções)
- [Relacionamento e Dependências entre Projetos](#relacionamento-e-dependências-entre-projetos)
- [Diagrama de Relacionamento](#diagrama-de-relacionamento)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Como Executar](#como-executar)
- [Exemplo de Entidades](#exemplo-de-entidades)
- [Exemplo de Comandos para Migrations](#exemplo-de-comandos-para-migrations)

---

## Sobre o Projeto
Este projeto é um exemplo prático de aplicação dos princípios da Clean Architecture em uma solução ASP.NET Core MVC. O objetivo é demonstrar como organizar um sistema de catálogo de produtos e categorias, separando responsabilidades e promovendo baixo acoplamento entre as camadas.

## Motivação
A Clean Architecture facilita a manutenção, evolução e testabilidade do software, separando regras de negócio, lógica de aplicação, infraestrutura e interface do usuário. Este exemplo serve como referência para quem deseja aplicar esses conceitos em projetos reais.

## Arquitetura Utilizada
A solução segue a Clean Architecture, com as seguintes camadas principais:
- **Domain**: Núcleo do domínio e regras de negócio.
- **Application**: Serviços de aplicação, DTOs, mapeamentos e CQRS.
- **Infrastructure.Data**: Persistência de dados, contexto EF Core, repositórios e migrações.
- **Infrastructure.IoC**: Configuração de injeção de dependência.
- **WebUI**: Interface web MVC, controllers, views e viewmodels.

## Estrutura da Solução
```
CleanArchitecture.sln
│
├── CleanArchitecture.Domain
├── CleanArchitecture.Application
├── CleanArchitecture.Infrastructure.Data
├── CleanArchitecture.Infrastructure.IoC
└── CleanArchitecture.WebUI
```

## Descrição das Camadas e Responsabilidades

### CleanArchitecture.Domain
- **Entities**: `Product`, `Category`, `Entity`
- **Interfaces**: `IProductRepository`, `ICategoryRepository`
- **Account**: `IAuthenticate`, `ISeedUserRoleInitial`, `IUser`
- **Validation**: Validação de dados e regras de negócio
- **Responsabilidade**: Definir o modelo de domínio, regras de negócio e contratos (interfaces) sem dependências externas.

### CleanArchitecture.Application
- **Services**: `ProductService`, `CategoryService`
- **DTOs**: `ProductDTO`, `CategoryDTO`
- **CQRS**: Commands, Queries, Handlers
- **Mappings**: `DomainViewModel`, `ViewModelDomain`
- **Interfaces**: `IProductService`, `ICategoryService`
- **Exceptions**: Tratamento de erros e exceções
- **Responsabilidade**: Orquestrar regras de negócio, realizar mapeamentos e expor serviços de aplicação.

### CleanArchitecture.Infrastructure.Data
- **Repositories**: `ProductRepository`, `CategoryRepository`
- **Context**: `ApplicationDbContext`
- **Migrations**: Migração de banco de dados
- **Identity**: Autenticação e controle de acesso
- **Responsabilidade**: Implementar persistência de dados, contexto EF Core, repositórios e autenticação.

### CleanArchitecture.Infrastructure.IoC
- **DependencyInjection**: Configuração de injeção de dependência
- **Responsabilidade**: Registrar e gerenciar dependências das camadas Application, Domain e Infrastructure.Data.

### CleanArchitecture.WebUI
- **Controllers**: `AccountController`, `CategoriesController`, `ProductsController`
- **Views**: Representação visual dos dados
- **Filters**: Filtros para requisições
- **Components**: Elementos reutilizáveis
- **ViewModels**: Modelos de dados para exibição
- **MapConfig**: Configuração de mapeamento
- **Responsabilidade**: Interface com o usuário, recebendo requisições, exibindo dados e interagindo com a camada de aplicação.

## Regras de Negócio
### Produto
- CRUD completo (consultar, criar, editar, excluir)
- Relacionamento com categoria (um-para-muitos)
- Validações:
  - Id, Stock e Price não podem ser negativos
  - Name e Description não podem ser nulos, vazios ou menores que 3 e 5 caracteres, respectivamente
  - Image pode ser nulo, mas não pode exceder 250 caracteres
  - Propriedades com setters privados e construtor parametrizado para garantir consistência

### Categoria
- CRUD completo
- Relacionamento com produtos
- Validações:
  - CategoryId não pode ser negativo
  - Name não pode ser nulo, vazio ou menor que 3 caracteres
  - Propriedades com setters privados e construtor parametrizado

## Nomenclatura e Convenções
- **Classe**: PascalCase (ex: Product, AddCategory)
- **Interface**: I + PascalCase (ex: IUser, ICalculateTotal)
- **Método/Propriedade**: PascalCase (ex: Address, FirstName)
- **Variáveis/Parâmetros**: camelCase (ex: stock, taxValue)
- **Constantes**: MAIÚSCULAS_COM_SUBLINHADO (ex: DISCOUNT_VALUE)
- **Idioma**: Inglês

## Relacionamento e Dependências entre Projetos
- **CleanArchitecture.Domain**: Não possui dependências.
- **CleanArchitecture.Application**: Depende de **Domain**.
- **CleanArchitecture.Infrastructure.Data**: Depende de **Domain**.
- **CleanArchitecture.Infrastructure.IoC**: Depende de **Domain**, **Application**, **Infrastructure.Data**.
- **CleanArchitecture.WebUI**: Depende de **Infrastructure.IoC**.

## Diagrama de Relacionamento
```
User Interface (WebUI)
   ↓
Infrastructure (Data/IoC)
   ↓
Domain/Application
```
- **Tests**: Conecta-se ao **Domain/Application** (exemplo: CleanArchitecture.Domain.Tests)
- **Infra.IoC**: Componente vertical para injeção de dependências

## Tecnologias Utilizadas
- ASP.NET Core MVC
- Entity Framework Core (Code-First)
- SQL Server (pode ser adaptado para outros bancos)
- Injeção de Dependência (IoC)
- Padrões: Repository, CQRS, MVC
- xUnit para testes (projeto sugerido: CleanArchitecture.Domain.Tests)

## Como Executar
1. Clone o repositório
2. Restaure os pacotes NuGet
3. Configure a string de conexão no `appsettings.json` em `CleanArchitecture.WebUI`
4. Execute as migrações do Entity Framework Core para criar o banco de dados
   - Exemplo de comando:
     ```powershell
     dotnet ef database update --project CleanArchitecture.Infrastructure.Data --startup-project CleanArchitecture.WebUI
     ```
5. Rode o projeto `CleanArchitecture.WebUI`

## Exemplo de Entidades

### Product
```csharp
public class Product {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    // Construtor parametrizado e validações no domínio
}
```

### Category
```csharp
public class Category {
    public int CategoryId { get; private set; }
    public string Name { get; private set; }
    public ICollection<Product> Products { get; private set; }
    // Construtor parametrizado e validações no domínio
}
```

## Exemplo de Comandos para Migrations
- Adicionar migration:
  ```powershell
  dotnet ef migrations add InitialCreate --project CleanArchitecture.Infrastructure.Data --startup-project CleanArchitecture.WebUI
  ```
- Atualizar banco de dados:
  ```powershell
  dotnet ef database update --project CleanArchitecture.Infrastructure.Data --startup-project CleanArchitecture.WebUI
  ```

---

Este projeto é um guia prático para quem deseja aprender e aplicar Clean Architecture em aplicações .NET modernas, promovendo separação de responsabilidades, testabilidade e manutenção facilitada.
