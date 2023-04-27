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

            CreateMap<ContatoDto, Contato>()
                .ForMember(dest => dest.DataNascimento, opt =>
                opt.MapFrom(src => TentaExtrairData(src.DataNascimento)));
        }

        public static DateTime? TentaExtrairData(string? dataSrt)
        {
            if (DateTime.TryParse(dataSrt, out DateTime _data))
            {
                return _data;
            }

            return null;
        }
    }
}
