# Central de Erros 

## Objetivo

<p align="justify">Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.</p>

<p align="justify">A arquitetura do projeto é formada por:</p>

### Backend - API

- criar endpoints para serem usados pelo frontend da aplicação
- criar um endpoint que será usado para gravar os logs de erro em um banco de dados relacional
- a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

### Frontend

- deve implementar as funcionalidades apresentadas nos wireframes
- deve ser acessada adequadamente tanto por navegadores desktop quanto mobile
- deve consumir a API do produto
- desenvolvida na forma de uma Single Page Application

> Status do Projeto: Em desenvolvimento

## Funcionalidades

- Consultas logs de erro por ambiente de desenvolvimento, homologação e teste
- Ordenação por level ou frequência
- Buscas por level, descrição e origem
- Arquivamento ou exclusão de logs

## Deploy da Aplicação com Azure

> 

## Desenvolvedoras

[<img src="srctoreadme/bruna.jpeg" width=115><br><sub>Bruna</sub>](https://github.com/beebones) |[<img src="srctoreadme/izabel.jpeg" width=115><br><sub>Izabel Pereira</sub>](https://github.com/chaihermes) | [<img src="srctoreadme/juliana.jpeg" width=115><br><sub>Juliana</sub>](https://github.com/Diana-ops) | [<img src="srctoreadme/margot.jpeg" width=115><br><sub>Margot Garcia</sub>](https://github.com/ahakawa) |
| :---: | :---: | :---: | :---:
