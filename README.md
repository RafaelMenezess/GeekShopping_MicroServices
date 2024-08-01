
# GeekShopping Microservices Project

Este é o projeto GeekShopping, um exemplo de arquitetura de microsserviços usando tecnologias modernas com .NET. O projeto foi desenvolvido com as seguintes tecnologias:

- ASP.NET
- .NET 6
- OAuth2
- OpenID
- JWT (JSON Web Tokens)
- Identity Server
- RabbitMQ
- API Gateway com Ocelot
- Swagger OpenAPI

## Arquitetura

O projeto está estruturado em vários microsserviços independentes que se comunicam entre si através de APIs e mensagens. A arquitetura inclui:

1. **Serviço de Autenticação**: Responsável por autenticar os usuários e fornecer tokens JWT.
2. **Serviços de Negócios**: Inclui serviços como carrinho de compras, catálogo de produtos, pedidos, etc.
3. **API Gateway**: Utiliza Ocelot para rotear solicitações para os microsserviços apropriados.
4. **Mensageria**: RabbitMQ é usado para comunicação assíncrona entre serviços.

## Configuração do Ambiente

### Pré-requisitos

- .NET 6 SDK
- Docker (para rodar RabbitMQ e outros serviços opcionais)
- Visual Studio 2022 (ou outro IDE de sua preferência)
- SQL Server (ou outro banco de dados de sua preferência)

### Passos para Configuração

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/RafaelMenezess/GeekShopping.git
   cd GeekShopping
   ```

2. **Configurar RabbitMQ com Docker**

   Use o Docker para configurar o RabbitMQ:

   ```bash
   docker run -d --hostname geekshopping-rabbit --name some-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management
   ```

3. **Configurar o Banco de Dados**

   Certifique-se de que o MySQL está rodando e configure a string de conexão nos arquivos de configuração de cada microsserviço.

4. **Restaurar Dependências e Construir a Solução**

   ```bash
   dotnet restore
   dotnet build
   ```

5. **Aplicar Migrações e Inicializar o Banco de Dados**

   Navegue até o diretório de cada microsserviço e aplique as migrações:

   ```bash
   dotnet ef database update
   ```

6. **Rodar os Serviços**

   Inicie cada microsserviço usando o Visual Studio ou o comando `dotnet run`.

### Microsserviços

1. **Autenticação (IdentityServer)**

   Responsável pela autenticação e geração de tokens JWT.

   ```bash
   cd Services/IdentityServer
   dotnet run
   ```

2. **Catálogo de Produtos**

   Serviço responsável por gerenciar o catálogo de produtos.

   ```bash
   cd Services/ProductCatalog
   dotnet run
   ```

3. **Carrinho de Compras**

   Serviço responsável por gerenciar o carrinho de compras dos usuários.

   ```bash
   cd Services/ShoppingCart
   dotnet run
   ```

4. **Pedidos**

   Serviço responsável pelo gerenciamento de pedidos.

   ```bash
   cd Services/Order
   dotnet run
   ```

5. **API Gateway (Ocelot)**

   Roteia solicitações para os serviços apropriados.

   ```bash
   cd APIGateway
   dotnet run
   ```

### Documentação da API

A documentação das APIs é gerada automaticamente usando o Swagger. Para acessar a documentação, navegue até o endpoint `/swagger` de cada microsserviço.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

