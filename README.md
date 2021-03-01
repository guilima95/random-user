# Back-End API Random User


REST API importando os dados do projeto: https://randomuser.me/documentation

## API

### Modelo de Dados:

MONGODB como banco de dados pela complexidade dos dados importados da api. 

Importação os dados para a Base de Dados com a versão mais recente do [Random User](https://randomuser.me/documentation#format) uma vez ao día.

A lista de arquivos do Random User, pode ser encontrada em: 

- https://randomuser.me/api

- Importação  dos dados de maneira paginada;
- Limitação  da importação com somente 2000 usuarios por vez;


### A REST API


Na REST API temos um CRUD com os seguintes endpoints:

   - `GET /`: 
   - `PUT /users/:userId`: 
   - `DELETE /users/:userId`: 
   - `GET /users/:userId`: 
   - `GET /users`:

- Unit Test para os endpoints da REST API
- Repository pattern / Notification pattern / IoC Pattern ...
- Projeto com suporte a Docker
- Autenticação usando JWT Bearer `API KEY` nos endpoints. Ref: https://learning.postman.com/docs/sending-requests/authorization/#api-key
- Documentação da API usando a biblioteca do Swagger utilizando o conceito de Open API 3.0;


