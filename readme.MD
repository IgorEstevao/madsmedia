# MadsMedia
## _MadsMedia mono repo_
Todas as API's, serviços, sites ou App's do MadsMedia se encontram nesse mono repo.
Cada uma das subpastas esta reprensentando uma segregação.

## Padrão do projetos
- Cada projeto deve possuir seu próprio arquivo readme, o qual deve contar detalhes de configuração
e comandos necessários para executar o projeto.
- Quano um projeto for iniciado o link para o readme dele deve ter inserino aqui, na tabela abaixo.
- Estutura do mono repo

A partir da pasta raiz, cada pasta deve representar uma segregação dos cógidos da MM.
```
├── backend
│   ├── web-server
│   ├── Videos.Api
│   └── api-auth
├── web
│   └── app
├── frontend 
│   └── app

```

## Run

### Frontend:
- comando: `cd frontend && npm i && npm start`

## Projetos ativos ou em implementação
| Projeto | README |
| ------ | ------ |
| web-server | [plugins/dropbox/README.md][PlDb] |
| Videos.Api | [README.MD](./backend/Videos.Api/readme.md) |
| Google Drive | [plugins/googledrive/README.md][PlGd] |

## License

MIT