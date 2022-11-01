using AutoMapper;
using CharcutariaAPI.Dtos;
using CharcutariaAPI.Models;
using CharcutariaAPI.Pagination;
using CharcutariaAPI.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CharcutariaAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public UsuarioController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
        {
            var usuario = await _uof.UsuarioRepository.Get().ToListAsync();


            var usuarioDto = _mapper.Map<List<UsuarioDTO>>(usuario);

            return usuarioDto;
        }

        

        [HttpGet("{id}", Name = "ObterUsuario")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var usuario = await _uof.UsuarioRepository.GetById(x => x.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound($"Usuario com o Id{id} não localizado");
            }

            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);

            return usuarioDto;
        }

        [HttpGet("UsuarioPorNome")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioPorNome([FromQuery] string nome)
        {
            var usuario = await _uof.UsuarioRepository.GetClientePorNome(nome);

            if (usuario == null)
            {
                return NotFound($"Não existem cliente com o nome {nome}");
            }

            return Ok(usuario);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            
            _uof.UsuarioRepository.Add(usuario);
            await _uof.Commit();

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = usuarioDto }, usuarioDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.UsuarioId)
            {
                return BadRequest();
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            _uof.UsuarioRepository.Update(usuario);
            
            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Delete(int id)
        {
            var usuario = await _uof.UsuarioRepository.GetById(p => p.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            _uof.UsuarioRepository.Delete(usuario);
            await _uof.Commit();

            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);

            return usuarioDto;
        }
    }
}
