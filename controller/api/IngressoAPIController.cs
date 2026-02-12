namespace CineFlowAPI.controller.api;

using Microsoft.AspNetCore.Mvc;
using CineFlowAPI.service.api;
using CineFlowAPI.model;
using CineFlowAPI.DTOs;
[ApiController]
[Route("api/[controller]")]
public class IngressoAPIController : ControllerBase
{

    private IngressoService _ingressoservice;

    public IngressoAPIController(IngressoService ingressoservice)
    {
        _ingressoservice = ingressoservice;
    }
    [HttpGet]
    public IActionResult GetIngressos()
    {
        var ingressos = _ingressoservice.ListarIngressos();
        if (ingressos == null || ingressos.Count == 0)
        {
            return NotFound();
        }
        var response = ingressos.Select(i => new IngressoResponseDto
        {
            Id = i.Id,
            SessaoId = i.SessaoId,
            LugarMarcado = i.LugarMarcado,
            Preco = i.Preco
        }).ToList();
        return Ok(ingressos);
    }

    [HttpPost]
    public IActionResult CriarIngresso([FromBody] CreateIngressoDto dto)
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingresso = new Ingresso
            {
                SessaoId = dto.SessaoId,
                LugarMarcado = dto.LugarMarcado,
                Preco = dto.Preco
            };

            var IngressoCriado = _ingressoservice.CriarIngresso(ingresso);
            var response = new IngressoResponseDto
            {
                Id = IngressoCriado.Id,
                SessaoId = IngressoCriado.SessaoId,
                LugarMarcado = IngressoCriado.LugarMarcado,
                Preco = IngressoCriado.Preco
            };
            return CreatedAtAction(nameof(GetIngressos), new { id = IngressoCriado.Id }, response);
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
    public IActionResult RemoverIngresso(int id)
    {
        try
        {
            _ingressoservice.RemoverIngresso(id);
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