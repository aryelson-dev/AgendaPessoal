using Aplicacao.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Aplicacao.Mapas.Perfis
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<Contato, ContatoDto>()
                .ForMember(dest => dest.DataNascimento, opt =>
                opt.MapFrom(src => src.DataNascimento.HasValue ? src.DataNascimento.Value.ToString("dd/MM/yyyy") : string.Empty));

            CreateMap<ContatoDto, Contato>();
        }
    }
}
