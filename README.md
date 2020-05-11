# Central de Erros 

## Desenvolvedoras

[<img src="srctoreadme/bruna.jpeg" width=115><br><sub>Bruna Silva</sub>](https://github.com/brunasouza2) |[<img src="srctoreadme/izabel.jpeg" width=115><br><sub>Izabel Pereira</sub>](https://github.com/izabel-neta) | [<img src="srctoreadme/juliana.jpeg" width=115><br><sub>Juliana Zacharias</sub>](https://github.com/juliananovais08) | [<img src="srctoreadme/margot.jpeg" width=115><br><sub>Margot Garcia</sub>](https://github.com/margotpaon) |
| :---: | :---: | :---: | :---:

> Status do Projeto: Em desenvolvimento

> [Deploy da Aplicação com Azure]()

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

## Funcionalidades

- Consultas logs de erro por ambiente de desenvolvimento, homologação e teste
- Ordenação por level ou frequência
- Buscas por level, descrição e origem
- Arquivamento ou exclusão de logs

## Linguagens, ferramentas e libs utilizadas

- [C#]()
- [.NET CORE](https://dotnet.microsoft.com/download): versão 2.2
- [SQL SERVER](https://www.microsoft.com/pt-br/download/details.aspx?id=55994): versão 2017 express
- [Entity Framework SQL Server](): versão 2.2.6
- [Identity Server](): versão 2.5.3
- [Swagger](): versão
  