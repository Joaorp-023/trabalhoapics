using Microsoft.AspNetCore.Mvc;
using BibliotecaApi.Models;
using BibliotecaApi.Repositories;

namespace BibliotecaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MateriaisController : ControllerBase
{
    private readonly IMaterialRepository _repository;

    public MateriaisController(IMaterialRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(_repository.ObterTodos());
    }

    [HttpGet("{id}")]
    public IActionResult Buscar(int id)
    {
        var material = _repository.ObterPorId(id);

        if (material == null)
            return NotFound("Material não encontrado.");

        return Ok(material);
    }

    [HttpPost("livro")]
    public IActionResult CadastrarLivro([FromBody] Livro livro)
    {
        if (string.IsNullOrWhiteSpace(livro.Titulo))
            return BadRequest("Título obrigatório.");

        if (livro.AnoPublicacao < 0)
            return BadRequest("Ano inválido.");

        if (string.IsNullOrWhiteSpace(livro.Autor))
            return BadRequest("Autor obrigatório.");

        if (livro.Paginas <= 0)
            return BadRequest("Número de páginas inválido.");

        var novo = _repository.Adicionar(livro);

        return CreatedAtAction(nameof(Buscar), new { id = novo.Id }, novo);
    }

    [HttpPost("revista")]
    public IActionResult CadastrarRevista([FromBody] Revista revista)
    {
        if (string.IsNullOrWhiteSpace(revista.Titulo))
            return BadRequest("Título obrigatório.");

        if (revista.AnoPublicacao < 0)
            return BadRequest("Ano inválido.");

        if (revista.Edicao <= 0)
            return BadRequest("Edição inválida.");

        if (revista.MesPublicacao < 1 || revista.MesPublicacao > 12)
            return BadRequest("Mês inválido.");

        var nova = _repository.Adicionar(revista);

        return CreatedAtAction(nameof(Buscar), new { id = nova.Id }, nova);
    }

    [HttpPut("livro/{id}")]
    public IActionResult AtualizarLivro(int id, [FromBody] Livro livro)
    {
        var material = _repository.ObterPorId(id);

        if (material == null)
            return NotFound();

        if (material is not Livro)
            return BadRequest("O material não é um livro.");

        if (string.IsNullOrWhiteSpace(livro.Titulo))
            return BadRequest("Título obrigatório.");

        if (livro.AnoPublicacao < 0)
            return BadRequest("Ano inválido.");

        if (string.IsNullOrWhiteSpace(livro.Autor))
            return BadRequest("Autor obrigatório.");

        if (livro.Paginas <= 0)
            return BadRequest("Número de páginas inválido.");

        _repository.Atualizar(id, livro);

        return Ok(livro);
    }

    [HttpPut("revista/{id}")]
    public IActionResult AtualizarRevista(int id, [FromBody] Revista revista)
    {
        var material = _repository.ObterPorId(id);

        if (material == null)
            return NotFound();

        if (material is not Revista)
            return BadRequest("O material não é uma revista.");

        if (string.IsNullOrWhiteSpace(revista.Titulo))
            return BadRequest("Título obrigatório.");

        if (revista.AnoPublicacao < 0)
            return BadRequest("Ano inválido.");

        if (revista.Edicao <= 0)
            return BadRequest("Edição inválida.");

        if (revista.MesPublicacao < 1 || revista.MesPublicacao > 12)
            return BadRequest("Mês inválido.");

        _repository.Atualizar(id, revista);

        return Ok(revista);
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        if (!_repository.Remover(id))
            return NotFound();

        return NoContent();
    }

    [HttpGet("{id}/descricao")]
    public IActionResult Descricao(int id)
    {
        var material = _repository.ObterPorId(id);

        if (material == null)
            return NotFound();

        return Ok(new
        {
            id = material.Id,
            tipo = material.GetType().Name,
            descricao = material.Descricao(),
            prazoEmprestimo = material.CalcularPrazo()
        });
    }

    [HttpPost("{id}/emprestar")]
    public IActionResult Emprestar(int id)
    {
        var material = _repository.ObterPorId(id);

        if (material == null)
            return NotFound();

        if (material is not IEmprestimo emprestavel)
            return BadRequest("Este material não pode ser emprestado.");

        return Ok(emprestavel.Emprestar());
    }
}