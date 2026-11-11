
# Relatório de Testes - BibliotecaApi

| Nº | Teste | Resultado Esperado |
|---|---|---|
| 1 | Listar materiais | 200 OK - Lista de livros e revistas retornada com sucesso. |
| 2 | Buscar material ID 1 | 200 OK - Material encontrado e dados exibidos |
| 3 | Buscar material ID 999 | 404 Not Found - Material não encontrado. |
| 4 | Cadastrar livro válido | 201 Created - Livro cadastrado e ID gerado automaticamente. |
| 5 | Cadastrar revista válida | 201 Created - Revista cadastrada com sucesso. |
| 6 | Livro sem título | 400 Bad Request - Cadastro recusado por título vazio. |
| 7 | Livro com 0 páginas | 400 Bad Request - Número de páginas inválido. |
| 8 | Revista com edição 0 | 400 Bad Request - Edição inválida. |
| 9 | Revista com mês 13 | 400 Bad Request - Mês de publicação inválido. |
| 10 | Atualizar livro | 200 OK - Dados do livro atualizados. |
| 11 | Atualizar revista | 200 OK - Dados da revista atualizados. |
| 12 | Atualizar material inexistente | 404 Not Found  Material não encontrado. |
| 13 | Excluir material existente | 204 No Content - Material excluído com sucesso. |
| 14 | Excluir material inexistente | 404 Not Found - Material não encontradp. |
| 15 | Consultar descrição do livro | 200 OK - Descrição exibida e prazo de 14 dias. |
| 16 | Consultar descrição da revista | 200 OK - Descrição exibida e prazo de 7 dias. |
| 17 | Realizar empréstimo de livro | 200 OK - Empréstimo permitido pela interface. |
| 18 | Tentar empréstimo de revista | 400 Bad Request - Empréstimo não permitido |
| 19 | Cadastrar vários materiais | 201 Created - Cada material recebe um ID diferente. |
| 20 | Excluir e cadastrar novamente | 201 Created - Novo material recebe um ID não repetido. |
