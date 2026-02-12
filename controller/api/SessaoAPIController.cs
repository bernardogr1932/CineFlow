namespace CineFlowAPI.controller.api;

using Microsoft.AspNetCore.Mvc;
using CineFlowAPI.service.api;
using CineFlowAPI.model;
using CineFlowAPI.DTOs;

[ApiController]
[Route("api/[controller]")]
public class SessaoAPIController : ControllerBase
{


    private SessaoService _sessaoservice;

    public SessaoAPIController(SessaoService sessaoservice)
    {
        _sessaoservice = sessaoservice;
    }
    [HttpGet]
    public IActionResult GetSessao()
    {
        var sessoes = _sessaoservice.ListarSessoes();
        if (sessoes == null || sessoes.Count == 0)
        {
            return NotFound();
        }
        var response = sessoes.Select(s => new SessaoResponseDto
        {
            Id = s.Id,
            FilmeId = s.FilmeId,
            SalaId = s.SalaId,
            DataHoraInicio = s.DataHoraInicio,
            DataHoraFim = s.DataHoraFim,
            LotacaoAtual = s.LotacaoAtual
        }).ToList();
        return Ok(response);
    }


    [HttpPost]
    public IActionResult CriarSessao([FromBody] CreateSessaoDto dto)
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sessao = new Sessao
            {
                FilmeId = dto.FilmeId,
                SalaId = dto.SalaId,
                DataHoraInicio = dto.DataHoraInicio
            };


            var SessaoCriada = _sessaoservice.CriarSessao(sessao);

            var response = new SessaoResponseDto
            {
                Id = SessaoCriada.Id,
                FilmeId = SessaoCriada.FilmeId,
                SalaId = SessaoCriada.SalaId,
                DataHoraInicio = SessaoCriada.DataHoraInicio,
                DataHoraFim = SessaoCriada.DataHoraFim,
                LotacaoAtual = SessaoCriada.LotacaoAtual
            };
            return CreatedAtAction(nameof(GetSessao), new { id = response.Id }, response);


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
    public IActionResult RemoverSessao(int id)
    {
        try
        {
            _sessaoservice.RemoverSessao(id);
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