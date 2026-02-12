using Microsoft.AspNetCore.Mvc;
using CineFlowAPI.service.api;
using CineFlowAPI.model;
using CineFlowAPI.controller.api;
namespace CineFlowAPI.controller.api;

using CineFlowAPI.Data;
using CineFlowAPI.DTOs;
using Microsoft.VisualBasic;

[ApiController]
[Route("api/[controller]")]
public class FilmeAPIController : ControllerBase
{

    private SessaoService _sessaoservice;
    private FilmeService _filmeService;
    private AppDbContext _context;
    public FilmeAPIController(FilmeService filmeservice, AppDbContext context)
    {

        _filmeService = filmeservice;
        _context = context;
    }
    [HttpGet]
    public IActionResult GetFilmes()
    {
        var filmes = _filmeService.ListarFilmes();
        if (filmes.Count == 0)
            return NotFound("Nenhum filme encontrado.");

        return Ok(filmes);
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromBody] CreateFilmeDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var filme = new Filme
        {
            Titulo = dto.Titulo,
            DuracaoMinutos = dto.DuracaoMinutos,
            Genero = dto.Genero
        };
        var filmeCadastrado = _filmeService.CadastrarFilme(filme);

        var response = new FilmeResponseDto
        {
            Id = filmeCadastrado.Id,
            Titulo = filmeCadastrado.Titulo,
            DuracaoMinutos = filmeCadastrado.DuracaoMinutos,
            Genero = filmeCadastrado.Genero
        };
        return CreatedAtAction(nameof(GetFilmes), new { id = response.Id }, response);
    }


    [HttpDelete("{id}")]
    public IActionResult RemoverFilme(int id)
    {
        try
        {
            _filmeService.RemoverFilme(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno no servidor.", detalhes = ex.Message });
        }
    }
}


