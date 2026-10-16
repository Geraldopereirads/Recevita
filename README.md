<h1 align="center">Recevita</h1>

## Objetivo

Construir uma plataforma moderna para amantes da culinária.

Integrar inteligência artificial para enriquecer a experiência dos usuários.

---

## Estrutura inicial

### Domain-Driven Design (DDD)

*Estou utilizando o DDD para organizar a estrutura da aplicação conforme o projeto cresce.*

*Essa abordagem permite separar melhor as responsabilidades de cada camada, tornando o código mais organizado, fácil de manter e preparado para receber novas funcionalidades.*

### S O L I D

*O desenvolvimento da aplicação segue os princípios SOLID, utilizando boas práticas para criar um código com responsabilidades bem definidas, baixo acoplamento e maior facilidade de manutenção, testes e evolução.*

---

### Tecnologias utilizadas

*C#*

Linguagem principal utilizada para o desenvolvimento da aplicação.

*.NET 10*

Framework utilizado para construção da API e gerenciamento da aplicação.

*SQL Server*

Banco de dados relacional utilizado para persistência das informações.

*Entity Framework*

ORM utilizado para mapeamento objeto-relacional e acesso ao banco de dados.

*Dapper*

Micro ORM utilizado em conjunto com o Entity Framework para consultas mais performáticas e maior controle sobre queries SQL específicas.

*FluentMigrator*

Utilizado para criação e versionamento do banco de dados de forma automatizada através de migrations em C#. No projeto, estou utilizando o FluentMigrator para criar tabelas, relacionamentos e manter a evolução do banco SQL Server organizada e versionada junto ao código da aplicação.

*FluentValidation*

Utilizei para validar os dados de entrada, mantendo as regras organizadas e desacopladas da lógica de negócio, além de permitir mensagens de erro personalizadas.

*Argon2*

Utilizei para proteger as senhas dos usuários por meio de criptografia baseada em hash, oferecendo maior segurança no armazenamento das credenciais e resistência a ataques de força bruta.

*Mapster (Application)*

Utilizado para facilitar a conversão de dados entre as camadas da aplicação (como DTOs e entidades), deixando o código mais limpo e organizado. Com isso, evitamos repetições desnecessárias e ganhamos mais agilidade na manutenção e evolução do sistema.

*xUnit*

Framework utilizado para criação e execução dos testes automatizados da aplicação. Com ele é possível validar o comportamento das funcionalidades de forma isolada, aumentando a confiabilidade do sistema e facilitando futuras manutenções.

*Bogus*

Biblioteca utilizada para geração de dados fictícios durante os testes. Isso permite criar cenários mais próximos da realidade sem a necessidade de criar dados manualmente, tornando os testes mais legíveis e consistentes.

*Shouldly*

Biblioteca de asserções utilizada nos testes automatizados para tornar as validações mais expressivas e fáceis de entender. O objetivo é melhorar a legibilidade dos testes e facilitar a identificação de falhas durante o desenvolvimento.



---

### Roadmap

- [ ] Registro de usuário 
- [ ] Criar regra de negócio para o cadastro
- [x] Criptografrar a senha do branco de dados
- [x] Armazenar no banco de dados as informações do usuário
- [x] criar migrations para as tabelas
- [x] Implementar testes de unidade para o validator
- [ ] Implementar testes de Unidade para a regra de negócio
- [ ] Implementar testes de integração para o fluxo de cadastro
- [x] Implementar FluentValidation para validar os dados
- [x] Implementar Entity Farmework
- [x] Implementar FluentMigrator
- [x] Implementar SQL Server
- [x] Criar Exceptions personalizadas
- [ ] Integrar Inteligencia Artificial
