using Acme.API.DTOs;
using Acme.API.Interfaces;
using Acme.API.Models;
using Acme.API.Repositories;
using AcmeAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var resultado = new List<UsuarioOutputDTO>();
            foreach (var usuario in usuarios)
            {
                resultado.Add(new UsuarioOutputDTO
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha
                });
            }
            return Ok(resultado);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            //convertendo o resultado para DTO
            var resultado = new UsuarioOutputDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };
            return Ok(resultado);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioInputDTO dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };
            await _usuarioRepository.AddAsync(usuario);
            return Ok();
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioInputDTO dto)
        {
            var usuario = new Usuario
            {
                Id = id,
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };
            await _usuarioRepository.UpdateAsync(usuario);
            return Ok();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
            return Ok();
        }

    }
}
