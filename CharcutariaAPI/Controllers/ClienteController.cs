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
    public class ClienteController : ControllerBase
    {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ClienteController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var cliente = await _uof.ClienteRepository.Get().ToListAsync();                     

            var clienteDto = _mapper.Map<List<ClienteDTO>>(cliente);

            return clienteDto;
        }
        
        
        [HttpGet("{id:int}", Name = "ObterCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _uof.ClienteRepository.GetById(x => x.ClienteId == id);

            if(cliente == null)
            {
                return NotFound($"Cliente com o Id{id}não localizado");
            }
            
            var clienteDto = _mapper.Map<ClienteDTO>(cliente);
            
            return clienteDto;
        }

        [HttpGet("ClientePorNome")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientePorNome([FromQuery] string nome)
        {
            var cliente = await _uof.ClienteRepository.GetClientePorNome(nome);

            if (cliente == null)
            {
                return NotFound($"Não existem cliente com o nome {nome}");
            }

            return Ok(cliente);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto){
           
            
            var cliente = _mapper.Map<Cliente>(clienteDto);
            
            _uof.ClienteRepository.Add(cliente);
            await _uof.Commit();

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return new CreatedAtRouteResult("ObterCliente",
                new { id = cliente.ClienteId }, clienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id != clienteDto.ClienteId)
            {
                return BadRequest();
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);

            _uof.ClienteRepository.Update(cliente);
            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var cliente = await _uof.ClienteRepository.GetById(p => p.ClienteId == id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _uof.ClienteRepository.Delete(cliente);
            await _uof.Commit();

            var clienteDto = _mapper.Map<ClienteDTO>(cliente);

            return clienteDto;
        }
       
        


    }
}
