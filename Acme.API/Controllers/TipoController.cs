using Acme.API.DTOs;
using Acme.API.Interfaces;
using Acme.API.Models;
using AcmeAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Acme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoRepository _tipoRepository;
        public TipoController(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }
        // GET: api/<TipoController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var tipos = await _tipoRepository.GetAllAsync();
            var resultado = new List<TipoOutputDTO>();
            foreach (var tipo in tipos)
            {
                resultado.Add(new TipoOutputDTO
                {
                    Id = tipo.Id,
                    Nome = tipo.Nome

                });
            }
            return Ok(resultado);
        }

        // GET api/<TipoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var tipo = await _tipoRepository.GetByIdAsync(id);

            //convertendo o resultado para DTO
            var resultado = new TipoOutputDTO
            {
                Id = tipo.Id,
                Nome = tipo.Nome
            };
            return Ok(resultado);
        }

        // POST api/<TipoeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoInputDTO dto)
        {
            var tipo = new Tipo
            {
                Nome = dto.Nome
            };
            await _tipoRepository.AddAsync(tipo);
            return Ok();
        }

        // PUT api/<TipoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoInputDTO dto)
        {
            var tipo = new Tipo
            {
                Id = id,
                Nome = dto.Nome
            };
            await _tipoRepository.UpdateAsync(tipo);
            return Ok();
        }

        // DELETE api/<TipoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tipoRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
