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
    public class FilialController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public FilialController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilialDTO>>> Get()
        {
            var filial = await _uof.FilialRepository.Get().ToListAsync();


            var filialDto = _mapper.Map<List<FilialDTO>>(filial);

            return filialDto;
        }

       


        [HttpGet("{id}", Name = "ObterFilial")]
        public async Task<ActionResult<FilialDTO>> Get(int id)
        {
            var filial = await _uof.FilialRepository.GetById(x => x.FilialId == id);

            if (filial == null)
            {
                return NotFound($"Filial com o Id{id}não localizado");
            }

            var filialDto = _mapper.Map<FilialDTO>(filial);

            return filialDto;
        }

        [HttpGet("cliente/{id}")]
        public async Task<ActionResult<IEnumerable<FilialClienteDTO>>> GetCliente(int id)
        {
            var filial = await _uof.FilialRepository.GetFilial(id);

            if (filial == null)
            {
                return NotFound($"Filial com o Id{id}não localizado");
            }

            var filialDto = _mapper.Map<List<FilialClienteDTO>>(filial);

            return filialDto;
        }

        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<IEnumerable<FilialUsuarioDTO>>> GetUsuario(int id)
        {
            var filial = await _uof.FilialRepository.GetUsuario(id);

            if (filial == null)
            {
                return NotFound($"Filial com o Id{id}não localizado");
            }

            var filialDto = _mapper.Map<List<FilialUsuarioDTO>>(filial);

            return filialDto;
        }





        [HttpGet("FilialPorCidade")]
        public async Task<ActionResult<IEnumerable<Filial>>> GetFilialPorCidade([FromQuery] string cidade)
        {
            var filial = await _uof.FilialRepository.GetFilialPorCidade(cidade);

            if (filial == null)
            {
                return NotFound($"Não existem filial na cidade de {cidade}");
            }

            return Ok(filial);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FilialDTO filialDto)
        {
            var filial = _mapper.Map<Filial>(filialDto);

            _uof.FilialRepository.Add(filial);
            await _uof.Commit();

            var filialDTO = _mapper.Map<FilialDTO>(filial);

            return new CreatedAtRouteResult("ObterCliente",
                new { id = filial.FilialId }, filialDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FilialDTO filialDto)
        {
            if (id != filialDto.FilialId)
            {
                return BadRequest();
            }

            var filial = _mapper.Map<Filial>(filialDto);

            _uof.FilialRepository.Update(filial);
            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FilialDTO>> Delete(int id)
        {
            var filial = await _uof.FilialRepository.GetById(p => p.FilialId == id);

            if (filial == null)
            {
                return NotFound();
            }

            _uof.FilialRepository.Delete(filial);
            await _uof.Commit();

            var filialDto = _mapper.Map<FilialDTO>(filial);

            return filialDto;
        }
    }
}
