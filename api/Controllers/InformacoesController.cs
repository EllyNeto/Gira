using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dal.IRepository;
using api.Dto;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformacoesController : ControllerBase
    {
        private readonly IInformacoesRepository _informacoesRepository;

        public InformacoesController(IInformacoesRepository informacoesRepository)
        {
            _informacoesRepository = informacoesRepository;
        }

        [HttpGet("Buscar por ID")]
        public async Task<ActionResult<Dto_Informacoes>> GetInformacoesById(int id)
        {
            var informacoes = await _informacoesRepository.BuscarPorId(id);
            if (informacoes == null)
            {
                return NotFound();
            }

            return informacoes;
        }

        [HttpGet("Buscar Todas Informaçoes")]
        public async Task<ActionResult<IEnumerable<Dto_Informacoes>>> GetTodasInformacoes()
        {
            var informacoes = await _informacoesRepository.BuscarTodasInformacoes();
            return informacoes;
        }

        [HttpPost("Cadastrar Informaçoes")]
        public async Task<ActionResult<Dto_Informacoes>> AdicionarInformacoes(Dto_Informacoes dto_informacoes)
        {
            var informacoesAdicionadas = await _informacoesRepository.Adicionar(dto_informacoes);
            return CreatedAtAction(nameof(GetInformacoesById), new { id = informacoesAdicionadas.Id }, informacoesAdicionadas);
        }

        [HttpPut("Actualizar Informaçoes")]
        public async Task<IActionResult> AtualizarInformacoes(int id, Dto_Informacoes dto_informacoes)
        {
            try
            {
                await _informacoesRepository.Actualizar(dto_informacoes, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Apagar Informaçoes")]
        public async Task<IActionResult> ApagarInformacoes(int id)
        {
            try
            {
                await _informacoesRepository.Apagar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
