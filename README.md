# Address Challenge MVC

Um projeto Web desenvolvido em ASP.NET Core MVC (.NET 8) focado no gerenciamento de endereços. O sistema permite o cadastro de usuários e a gestão completa (CRUD) de endereços vinculados a esses usuários, com busca automática de CEP e exportação de relatórios.

## 🚀 Tecnologias Utilizadas

- **Backend:** ASP.NET Core MVC (.NET 8), C#
- **Banco de Dados:** SQL Server (via Docker), Entity Framework Core
- **Frontend:** HTML5, CSS3, Bootstrap 5, Vanilla JavaScript
- **Integração:** API ViaCEP

## ⚙️ Funcionalidades

- **Autenticação (Login):** Sistema seguro baseado em Cookies, isolando e protegendo os dados para que um usuário acesse apenas seus próprios registros.
- **CRUD de Endereços:** Inserção, listagem, edição e exclusão de endereços com interface amigável e responsiva.
- **Autopreenchimento (ViaCEP):** Integração frontend que preenche Logradouro, Bairro, Cidade e UF automaticamente ao digitar um CEP de 8 dígitos.
- **Exportação CSV:** Geração e download de relatórios dinâmicos contendo todos os endereços do usuário logado, perfeitamente compatível com Excel (incluindo tratamento de acentos via BOM).

## 🛠️ Como rodar o projeto localmente

### 1. Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (ou um SQL Server local na porta 1433).
- Ferramenta global do EF Core (caso precise rodar comandos CLI: `dotnet tool install --global dotnet-ef`).

### 2. Preparando o Ambiente
```bash
# Entre na pasta raiz do projeto
cd address-challenge-mvc

# Levante o contêiner do banco de dados
docker-compose up -d
```

A connection string já está configurada no `appsettings.json` conectando automaticamente ao SQL Server Dockerizado.

### 3. Criando as Tabelas do Banco
Você pode aplicar as configurações do banco de duas formas:
- **Via EF Core CLI (Recomendado):**
  ```bash
  dotnet ef database update
  ```
- **Via Script SQL:** Execute o arquivo `scripts.sql` presente na raiz deste projeto no seu gerenciador de banco de dados preferido (como Azure Data Studio ou DBeaver).

### 4. Rodando a Aplicação
```bash
dotnet run
```
Acesse no seu navegador o endereço HTTP indicado pelo terminal (ex: `http://localhost:5294`).

## 🔑 Acesso de Teste Padrão

Para facilitar a avaliação técnica, ao rodar a aplicação, o sistema criará automaticamente o seguinte usuário administrador se o banco estiver vazio:

- **Usuário:** `admin`
- **Senha:** `admin`

---
*Projeto construído como Teste Técnico para avaliação de Engenharia de Software (Microsoft Ecosystem).*
