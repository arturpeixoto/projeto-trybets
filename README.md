# Projeto TryBets

Este projeto é uma API desenvolvida para lidar com serviços de um site de apostas de jogos, estruturada em microsserviços. A API permite o cadastro e autenticação de usuários, gerenciamento de times e partidas, realização de apostas, e atualização dinâmica das odds com base nas apostas realizadas.

## Estrutura do Projeto

A API é composta por 4 entidades principais:

- **Users**: Gerencia os dados dos usuários.
- **Teams**: Armazena informações sobre os times que participam das partidas.
- **Matches**: Registra as partidas, com detalhes sobre times participantes, datas, horários, valor apostado, status de finalização e time vencedor.
- **Bets**: Armazena as apostas realizadas, com informações sobre o usuário, a partida, o time escolhido e o valor apostado.

## Funcionalidades

- Cadastro de novos usuários.
- Autenticação de usuários.
- Consulta de times e partidas.
- Realização de apostas com odds dinâmicas.
- Atualização automática das odds com base nas apostas.

## Pré-requisitos

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/arturpeixoto/projeto-trybets.git
```

### 2. Acesse o diretório do projeto

```bash
cd projeto-trybets
```

### 3. Suba os microsserviços com Docker Compose

Execute o seguinte comando para construir e inicializar todos os microsserviços:

```bash
docker compose -f docker-compose.microservices.yml up -d --build
```

## Como usar

Com os microsserviços em execução, você poderá interagir com a API para cadastrar usuários, realizar apostas e consultar times e partidas. A API está pronta para ser usada com ferramentas como o **Postman** ou **curl** para testar os endpoints disponíveis.

## Tecnologias Utilizadas

- C#
- .NET Core
- Docker
- Docker Compose

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.
