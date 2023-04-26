using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Aplicacao.Mapas.Perfis
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<Contato, ContatoDto>().ReverseMap();
        }
    }
}
