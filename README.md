# FutManagement API

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-9-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

## 📖 Introdução

**FutManagement API** é uma API RESTful robusta e completa, desenhada para simular um sistema de gestão de transferências de futebol. O projeto permite o gerenciamento completo de Jogadores, Clubes e todo o ciclo de vida de uma Transferência, desde a proposta e validação de regras de negócio até a sua finalização, com ajustes de orçamentos e movimentação de jogadores.

Este projeto foi construído como um estudo de caso aprofundado e uma peça de portfólio, utilizando as melhores e mais modernas práticas de arquitetura de software e do ecossistema .NET.

## ✨ Arquitetura e Boas Práticas

O pilar deste projeto é a sua arquitetura e as práticas de desenvolvimento profissional que foram implementadas.

### Arquitetura Utilizada

* **Clean Architecture (Arquitetura Limpa):** A solução é organizada em quatro projetos distintos (`Core`, `Application`, `Infrastructure`, `Presentation`), garantindo uma separação clara de responsabilidades, baixo acoplamento e alta coesão. A camada de domínio (`Core`) é totalmente independente de tecnologias externas.
* **CQRS (Command Query Responsibility Segregation):** Usamos o padrão CQRS para separar as operações de escrita (Commands) das operações de leitura (Queries). Isso simplifica a lógica, otimiza as consultas e torna o código mais fácil de manter.
* **MediatR:** A biblioteca MediatR foi utilizada para implementar o padrão Mediator, desacoplando completamente os `Controllers` dos `Handlers` e servindo como o barramento central para nossas `Commands` e `Queries`.
* **Inversão de Dependência (DIP):** Aplicamos rigorosamente o Princípio da Inversão de Dependência. A camada `Application` define "contratos" (interfaces) e a camada `Infrastructure` fornece as implementações, mantendo nossa lógica de negócio agnóstica a detalhes de infraestrutura (como o banco de dados ou o gerador de JWT).

### Testes Realizados

A qualidade e a fiabilidade do código são garantidas através de uma suíte de **Testes de Unidade** com **xUnit**.
* **Foco na Lógica de Negócio:** Os testes são focados na camada `Application`, validando o comportamento de cada `CommandHandler` e `QueryHandler` de forma isolada.
* **Mocking de Dependências:** Usamos a biblioteca **Moq** para criar "falsificações" de dependências externas (como o `IAppDbContext`), permitindo que os testes sejam executados rapidamente e sem a necessidade de um banco de dados real.
* **Asserções Fluentes:** A biblioteca **FluentAssertions** foi usada para criar verificações de teste mais legíveis e expressivas.

### Boas Práticas Adotadas

* **Tratamento de Exceções Global:** Um middleware centralizado captura todas as exceções não tratadas e as converte em respostas `ProblemDetails` (RFC 7807), o padrão para erros em APIs REST.
* **Validação com FluentValidation:** Regras de negócio e de entrada de dados são definidas de forma declarativa e executadas automaticamente através de um pipeline do MediatR.
* **Segurança com JWT:** Implementação de um fluxo completo de autenticação e autorização com JSON Web Tokens (Bearer), incluindo registo de utilizadores, hashing de senhas (`BCrypt.Net-Next`) e autorização baseada em perfis (`Roles`).
* **Logging Estruturado com Serilog:** Configuração de logs estruturados para ficheiro e console, facilitando a análise e o monitoramento da aplicação.
* **Otimização com Caching:** Uso de cache in-memory (`IMemoryCache`) para otimizar o desempenho de consultas a dados estáticos.
* **Background Jobs com Hangfire:** Implementação de tarefas em segundo plano para operações que não devem bloquear a resposta da API (como o envio de notificações).
* **Containerização com Docker:** A aplicação e o seu banco de dados PostgreSQL são totalmente containerizados e orquestrados com `docker-compose`, garantindo um ambiente de desenvolvimento consistente e portável.
* **Gestão de Segredos com `.env`:** As credenciais sensíveis (banco de dados, segredo do JWT) são geridas através de um ficheiro `.env` (não versionado no Git), seguindo as melhores práticas de segurança.
* **Documentação de API com Scalar:** A API é documentada usando a especificação OpenAPI, com uma interface de utilizador moderna e interativa fornecida pelo Scalar.

## 🚀 Tecnologias e Ferramentas

* **Framework:** .NET 9
* **Linguagem:** C#
* **Banco de Dados:** PostgreSQL
* **ORM:** Entity Framework Core 8
* **Arquitetura:** Clean Architecture, CQRS
* **Bibliotecas Chave:**
    * `MediatR` - Implementação do padrão Mediator
    * `FluentValidation` - Validações declarativas
    * `Serilog` - Logging Estruturado
    * `Hangfire` - Execução de Background Jobs
    * `BCrypt.Net-Next` - Hashing de Senhas
    * `Microsoft.AspNetCore.Authentication.JwtBearer` - Autenticação com JWT
    * `Microsoft.Extensions.Caching.Memory` - Caching In-Memory
    * `Scalar.AspNetCore` - Documentação da API
* **Testes:**
    * `xUnit` - Framework de Teste
    * `Moq` - Biblioteca de Mocking
    * `FluentAssertions` - Biblioteca de Asserções
* **Infraestrutura:**
    * `Docker` e `docker-compose` - Containerização e Orquestração

## ⚙️ Como Rodar o Projeto Localmente

Para executar a aplicação e o banco de dados no seu ambiente local, siga estes passos.

### Pré-requisitos
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado e em execução.
* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) instalado.

### Passos

1.  **Clone o Repositório**
    ```bash
    git clone https://github.com/babingthon/FutTransferer_API.git
    cd FutTransferer_API
    ```

2.  **Crie o Ficheiro de Segredos (`.env`)**
    Na pasta raiz do projeto, crie um ficheiro chamado `.env` e adicione o seguinte conteúdo. Este ficheiro contém as credenciais que serão usadas pelo `docker-compose`.

    ```env
    # Database Credentials
    POSTGRES_DB=FutebolDB
    POSTGRES_USER=postgres
    POSTGRES_PASSWORD=mysecretpassword

    # JWT Secret
    JWT_SECRET=UMA-CHAVE-SECRETA-MUITO-FORTE-E-LONGA-QUE-VOCE-DEVE-INVENTAR-AQUI-123
    ```
    > **Importante:** O ficheiro `.env` deve ser adicionado ao seu `.gitignore` para nunca ser enviado para o repositório público.

3.  **Inicie os Containers**
    Com o Docker em execução, use o `docker-compose` para construir a imagem da API e iniciar os containers da API e do banco de dados.

    ```bash
    docker-compose up --build
    ```
    Aguarde até que os logs se estabilizem. Na primeira execução, a nossa lógica de migração automática criará as tabelas necessárias no banco de dados.

4.  **Aceda à API**
    A API estará a rodar e disponível. A documentação interativa do Scalar estará na URL raiz:
    * **[http://localhost:8080](http://localhost:8080)**

    O dashboard do Hangfire estará disponível em:
    * **[http://localhost:8080/hangfire](http://localhost:8080/hangfire)**

5.  **Povoar o Banco de Dados (Seed)**
    O banco de dados será criado com as tabelas e os dados de `seed` de Países e Utilizadores que estão no código. Para adicionar os dados em massa de Jogadores e Clubes, execute o seu script SQL (`seed.sql` ou similar) diretamente no banco de dados usando um cliente como DBeaver, DataGrip ou pgAdmin.

## 🧪 Como Rodar os Testes

Para executar a suíte de testes de unidade, navegue para a pasta raiz do projeto no seu terminal e execute:

```bash
dotnet test
