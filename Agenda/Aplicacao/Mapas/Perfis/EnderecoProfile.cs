using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Aplicacao.Mapas.Perfis
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
        }
    }
}
