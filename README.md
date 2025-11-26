# RabbitPedidos

Uma API backend que faz o cadastro de pedidos e publica em uma fila do RabbitMQ, e utiliza Docker com o Docker Compose para executar a aplicação, o banco de dados e o RabbitMQ.




## Stack utilizada

**API:** .NET 10, ASPNET, Entity Framework

**Banco de Dados:** MySQL

**Menssage Broker:** RabbitMQ

**Infraestrutura:** Docker com Docker Compose


## Funcionalidades

- Cadastro de pedidos
- Consultar todos os pedidos realizados
- Publicar na fila 'pedido.criado' do RabbitMQ após criar um pedido
- Um Listener/Consumer para processar os pedidos cadastrados(alterando status de Pendente para Processado)


## Documentação da API

#### Busca todos os pedidos

```http
  GET /api/v1/pedidos
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` | **Obrigatório**. A chave da sua API |

#### Cadastra um pedido

```http
  POST /api/v1/pedidos
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `NomeCliente`      | `string` | Nome do cliente  |
| `Descricao`      | `string` | Descrição do pedido  |
| `Valor`      | `string` | Valor do pedido  |


## Exemplo de JSON para cadastrar pedido
```json
{
    "NomeCliente": "Maria das Graças",
    "Descricao": "Pedidos de itens para casa",
    "Valor": 500.00
}
```



## Passo-a-passo para execução

Clone o projeto

```bash
  git clone git@github.com:CodeHunter6667/RabbitPedidos.git
```

Entre no diretório do projeto

```bash
  cd RabbitPedidos
```
Certificar-se que possui o Docker e o Docker Compose instalado na máquina

Executar o docker-compose

```bash
  docker compose up -d
```

Para parar a execução

```bash
  docker compose down
```


## Realizando requisições pelo Postman

Utilize a collection do Postman: https://.postman.co/workspace/My-Workspace~ca78e6bd-587f-43d6-861f-879d8836eaba/request/28884519-551f315d-faaa-4e16-a53d-a05579635076?action=share&creator=28884519&ctx=documentation

Nessa collection já se encontram uma requisição GET e uma requisição POST.

Utilizando o código de exemplo, insira na aba Body na configuração Raw(JSON);

* Esperado Status Code 201: Created com os dados que foram salvos no banco de dados;

Para consultar os pedidos realizados, alterar para a requisição GET e enviar a requisição;

* Esperado Status Code 200: OK com a lista de todos os pedidos cadastrados;
## Funcionalidades do RabbitMQ

* Recebe a mensagem publicada na fila 'pedido.criado';
* Processa o pedido pelo Listener/Consumer esperando 15 segundos para processar o pedido e alterar seu status de Pendente para Processado;

