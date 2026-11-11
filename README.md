
# BibliotecaApi

## Integrantes
João Pedro Rebequi Cavalieri - 114.016

## Descrição
API para cadastrar, consultar, atualizar e excluir livrps e revistas.

## Tecnologias
C#, .NET 10, ASP.NET Core e Swagger.

## Como executar
1. Abrir o projeto no VS Code
2. Executar `dotnet run` no terminal.
3. Acessar `http://localhost:5252/swagger` (ou a porta indicada)

## Endpoints
- GET /api/Materiais
- GET /api/Materiais/{id}
- POST /api/Materiais/livro
- POST /api/Materiais/revista
- PUT /api/Materiais/livro/{id}
- PUT /api/Materiais/revista/{id}
- DELETE /api/Materiais/{id}
- GET /api/Materiais/{id}/descricao
- POST /api/Materiais/{id}/emprestar

## Testes
Realizados pelo Swagger. Casos de teste descritos em RELATORIO_TESTES.md
