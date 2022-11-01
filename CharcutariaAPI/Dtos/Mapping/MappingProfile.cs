using AutoMapper;
using CharcutariaAPI.Models;

namespace CharcutariaAPI.Dtos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Filial, FilialDTO>().ReverseMap();
            CreateMap<Filial, FilialClienteDTO>().ReverseMap();
            CreateMap<Filial, FilialUsuarioDTO>().ReverseMap();





        }
    }
}
