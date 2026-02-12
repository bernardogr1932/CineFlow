namespace CineFlowAPI.controller.api;

using Microsoft.AspNetCore.Mvc;
using CineFlowAPI.service.api;
using CineFlowAPI.model;
using CineFlowApi.DTOs;
using CineFlowAPI.DTOs;

[ApiController]
[Route("api/[controller]")]
public class SalaAPIController : ControllerBase
{
    private SalaService _salaService;

    public SalaAPIController(SalaService salaservice)
    {
        _salaService = salaservice;
    }

    [HttpGet]
    public IActionResult GetSalas()
    {
        var salas = _salaService.ListarSalas();
        if (salas == null || salas.Count == 0)
        {
            return NotFound();
        }
        var response = salas.Select(s => new SalaResponseDto
        {
            Id = s.Id,
            Nome = s.Nome,
            CapacidadeTotal = s.CapacidadeTotal
        }).ToList();

        return Ok(response);
    }

    [HttpPost]
    public IActionResult CadastrarSala([FromBody] CreateSalaDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sala = new Sala
            {
                Nome = dto.Nome,
                CapacidadeTotal = dto.CapacidadeTotal
            };

            var salaCadastrada = _salaService.CadastrarSala(sala);

            var response = new SalaResponseDto
            {
                Id = salaCadastrada.Id,
                Nome = salaCadastrada.Nome,
                CapacidadeTotal = salaCadastrada.CapacidadeTotal
            };
            return CreatedAtAction(nameof(GetSalas), new { id = response.Id }, response);

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

    [HttpDelete("{id}")]
    public IActionResult RemoverSala(int id)
    {
        try
        {
            _salaService.RemoverSala(id);
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
