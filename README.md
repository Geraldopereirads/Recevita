<h1 align="center">Recevita</h1>

## Objetivo

### Construir uma plataforma moderna para amantes da culinária.
### Integrar inteligência artificial para enriquecer a experiência dos usuários.

---

## Estrutura inicial

### O projeto segue a arquitetura **DDD (Domain-Driven Design)**.

---

## Tecnologias utilizadas

### C#
Linguagem principal utilizada para o desenvolvimento da aplicação.

### .NET 8
Framework utilizado para construção da API e gerenciamento da aplicação.

### SQL Server
Banco de dados relacional utilizado para persistência das informações.

### Entity Framework
ORM utilizado para mapeamento objeto-relacional e acesso ao banco de dados.

### FluentValidation (Application)
Utilizei para validar os dados de entrada, mantendo as regras organizadas e desacopladas da lógica de negócio, além de permitir mensagens de erro personalizadas.

---

### Roadmap

- [ ] Registro de usuário 
- [ ] Criar regra de negócio para o cadastro
- [ ] Criptografrar a senha do branco de dados
- [ ] Armazenar no banco de dados as informações do usuário
- [ ] criar migrations para as tabelas
- [ ] Implementar testes de Unidade para o validator
- [ ] Implementar testes de Unidade para a regra de negócio
- [ ] Implementar testes de integração para o fluxo de cadastro
- [x] Implementar FluentValidation para validar os dados
- [ ] Implementar Entity Farmework
- [ ] Implementar SQL Server
