# LibraryApi - Descrição do Projeto

A LibraryApi é uma API desenvolvida em dotnet que oferece funcionalidades para gerenciar livros e usuários em uma biblioteca. Ela foi criada com o objetivo de simplificar a gestão de livros e usuários, proporcionando uma solução eficiente e escalável para sistemas de bibliotecas.

## Funcionalidades

A API oferece as seguintes funcionalidades:

- Cadastro de livros: Permite cadastrar novos livros no sistema, incluindo informações como título, autor, gênero e número de exemplares disponíveis.

- Cadastro de usuários: Permite cadastrar novos usuários, como membros da biblioteca, registrando seus nomes e informações de contato.

- Consulta de livros e usuários: Oferece a possibilidade de consultar a lista completa de livros e usuários cadastrados no sistema.

- Atualização de informações: Permite atualizar os dados dos livros e usuários existentes no sistema, incluindo alterações de título, autor, status de empréstimo, entre outros.

- Exclusão de registros: Possibilita a exclusão de livros e usuários, caso não sejam mais necessários no sistema.

## Tecnologias Utilizadas

Para executar o projeto da LibraryApi, é necessário ter as seguintes dependências instaladas:

1. **.NET SDK:** A API foi desenvolvida em dotnet, portanto, é necessário ter o .NET SDK instalado em sua máquina. Você pode verificar a versão do .NET SDK instalada executando o comando `dotnet --version` no terminal.

2. **Banco de Dados PostgreSQL:** A LibraryApi utiliza o PostgreSQL como banco de dados para armazenar as informações dos livros e usuários. Certifique-se de ter o PostgreSQL instalado e configurado corretamente, incluindo as credenciais de acesso ao banco de dados.

## Como Executar o Projeto

Agora que você tem as dependências instaladas, siga os passos abaixo para executar a LibraryApi:

1. Clone o repositório do projeto para o seu ambiente local:

```
git clone https://github.com/seu-usuario/library-api.git
```

Substitua "seu-usuario" pelo seu nome de usuário do GitHub.

2. Acesse o diretório do projeto:

```
cd library-api
```

3. Restaure as dependências do projeto utilizando o NuGet:

```
dotnet restore
```

4. Configure a conexão com o banco de dados PostgreSQL:

Abra o arquivo `appsettings.json` no diretório do projeto e localize a seção `ConnectionStrings`. Insira a string de conexão com o banco de dados PostgreSQL, informando o nome do banco, usuário e senha corretos.

5. Crie o banco de dados:

Execute o seguinte comando para criar o banco de dados e aplicar as migrações necessárias:

```
dotnet ef database update
```

Isso criará as tabelas necessárias no banco de dados PostgreSQL com base nas configurações definidas no DbContext.

6. Execute o projeto:

```
dotnet run
```

A API estará em execução em `http://localhost:5000`. Você poderá acessar a documentação da API através do Swagger em `http://localhost:5000/swagger`, onde encontrará informações detalhadas sobre cada rota e funcionalidade disponível.

Agora você está pronto para utilizar a LibraryApi e aproveitar suas funcionalidades para gerenciar livros e usuários em uma biblioteca de forma eficiente e intuitiva.

Caso tenha alguma dúvida ou encontre algum problema durante a execução do projeto, sinta-se à vontade para entrar em contato ou abrir uma issue no repositório do projeto. Boa codificação! 😊📚